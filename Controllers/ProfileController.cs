using CrowdFundingApp.Models;
using CrowdFundingApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.Controllers
{
    public class ProfileController : Controller
    {
        ApplicationContext db;
        UserManager<User> _userManager;
        SignInManager<User> _signInManager;

        public ProfileController (ApplicationContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            db = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<ActionResult> ProfileAsync(string name, string about, string beginDate, string endDate, double totalDonate, double needDonate, SortState sortOrder = SortState.NameAsc)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ProfileViewModel model = new ProfileViewModel
            {
                userBonus = getUserBonus(user),
                companies = filterCompany(user, name, about, beginDate, endDate, totalDonate, needDonate, sortOrder),
                user = user,
            };
            return View(model);
        }

        private List<UserBonus> getUserBonus(User user)
        {
            return db.UserBonus.Include(u => u.user).Include(b => b.bonus).Include(c => c.company).Where(u => u.user == user).ToList();
        }

        public async Task<IActionResult> editLoginAsync(ProfileViewModel model, string userId)
        {
            User user = await _userManager.FindByIdAsync(userId);
            user.UserName = model.user.UserName;
            await _userManager.UpdateAsync(user);
            await reloginAsync(user);
            return RedirectToAction("Profile","Profile");
        }

        public async Task<IActionResult> changeAvatarAsync(ProfileViewModel model, string userId)
        {
            User user = await _userManager.FindByIdAsync(userId);
            user.profileImg = model.user.profileImg;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Profile", "Profile");
        }


        public async Task reloginAsync(User user)
        {
            await _signInManager.SignOutAsync();
            await _signInManager.SignInAsync(user, false);
        }

        private List<Company> filterCompany(User user, string name, string about, string beginDate, string endDate, double totalDonate, double needDonate, SortState sortOrder)
        {
            IQueryable<Company> company = db.Company.Include(u => u.creater).Where(u => u.creater == user);

            if (!String.IsNullOrEmpty(name))
            {
                company = company.Where(p => p.companyName.Contains(name));
            }
            if (!String.IsNullOrEmpty(about))
            {
                company = company.Where(p => p.about.Contains(about));
            }
            if (!String.IsNullOrEmpty(beginDate))
            {
                company = company.Where(p => p.about.Contains(beginDate));
            }
            if (!String.IsNullOrEmpty(endDate))
            {
                company = company.Where(p => p.about.Contains(endDate));
            }
            if(totalDonate != 0)
            {
                company = company.Where(p => p.totaldonate == totalDonate);
            }
            if(needDonate != 0)
            {
                company = company.Where(p => p.needDonate == needDonate);
            }

            ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            ViewData["NeedDonateSort"] = sortOrder == SortState.NeedAsc ? SortState.NeedDesc : SortState.NeedAsc;
            ViewData["TotalDonateSort"] = sortOrder == SortState.TotalAsc ? SortState.TotalDesc : SortState.TotalAsc;
            ViewData["DateBeginSort"] = sortOrder == SortState.DateCreateAsc ? SortState.DateCreateDesc : SortState.DateCreateAsc;
            ViewData["DateEndSort"] = sortOrder == SortState.DateEndAsc ? SortState.DateEndDesc : SortState.DateEndAsc;

            company = sortOrder switch
            {
                SortState.NameDesc => company.OrderByDescending(s => s.companyName),
                SortState.NeedAsc => company.OrderBy(s => s.needDonate),
                SortState.NeedDesc => company.OrderByDescending(s => s.needDonate),
                SortState.TotalAsc => company.OrderBy(s => s.totaldonate),
                SortState.TotalDesc => company.OrderByDescending(s => s.totaldonate),
                SortState.DateCreateAsc => company.OrderBy(s => s.startDate),
                SortState.DateCreateDesc => company.OrderByDescending(s => s.startDate),
                SortState.DateEndAsc => company.OrderBy(s => s.endDate),
                SortState.DateEndDesc => company.OrderByDescending(s => s.endDate),
                _ => company.OrderBy(s => s.companyName),
            };

            return company.ToList();
        }
    }
}
