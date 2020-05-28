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
    public class CompanyProfileController : Controller
    {
        ApplicationContext db;
        UserManager<User> _userManager;

        public CompanyProfileController(ApplicationContext context, UserManager<User> userManager)
        {
            db = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> CompanyProfileAsync(int companyId)
        {
            Company company = db.Company.Include(b => b.BonusList).Include(n => n.News).Where(c => c.companyId == companyId).FirstOrDefault();
            CompanyProfileViewModel model = new CompanyProfileViewModel
            {
                companyProfile = company,
                themeName = db.CompanyTheme.Include(t => t.theme).Where(t => t.company == company).FirstOrDefault(),
                comments = db.Comments.Include(u => u.user).Include(l => l.LikeLists).Where(c => c.company == company).ToList(),
                currentUser = await _userManager.GetUserAsync(HttpContext.User)
             };

            return View(model);
        }


        public async Task<IActionResult> addCommentAsync(CompanyProfileViewModel model, int companyId)
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            Company company = getCompanyById(companyId);
            Comments comment = new Comments { company = company, user = user, comentText = model.comment.comentText, comentDate = DateTime.Now.ToString(), like = 0 };
            db.Comments.Add(comment);
            await db.SaveChangesAsync();
            return RedirectToAction("CompanyProfile", "CompanyProfile", new { companyId });
        }
        

        public IActionResult EditCompany(int companyId)
        {
            Company company = getCompanyById(companyId);
            CompanyProfileViewModel model = new CompanyProfileViewModel
            {
                companyProfile = db.Company.Where(c => c.companyId == companyId).FirstOrDefault(),
                bonusList = db.BonusList.Include(v => v.company).Where(c => c.company == company).ToList()
            };

            return View(model);
        }

        public IActionResult Save(CompanyProfileViewModel model, int companyId)
        {
            Company company = getCompanyById(companyId);
            company.companyName = model.companyName;
            db.SaveChanges();
            return RedirectToAction("CompanyProfile", "CompanyProfile", new { company.companyId });
        }

        public async Task<IActionResult> saveBonusAsync(CompanyProfileViewModel model, int companyId)
        {
            Company company = getCompanyById(companyId);
            BonusList bonusList = new BonusList { bonusName = model.bonus, bonusCost = model.bonusCost, company = company };
            db.BonusList.Add(bonusList);
            await db.SaveChangesAsync();
            return RedirectToAction("EditCompany", "CompanyProfile", new { company.companyId });
        }

        public IActionResult addBonus(int companyId)
        {
            Company company = getCompanyById(companyId);
            CompanyProfileViewModel model = new CompanyProfileViewModel
            {
                companyProfile = company
            };
            return View(model);
        }

        public IActionResult deleteCompany(int companyId)
        {
            Company company = db.Company.Include(t => t.CompanyTheme).Include(c => c.Comments).Include(t => t.CompanyTag).Include(n => n.News).Include(b => b.BonusList).Where(c => c.companyId == companyId).FirstOrDefault(); //bad idea but it worked (check caskade delete)
            db.Company.Remove(company);
            db.SaveChanges();
            return RedirectToAction("index", "Home");
        }

        public async Task<IActionResult> likeAsync(CompanyProfileViewModel model, int companyId)
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            Comments comment = db.Comments.FirstOrDefault(c => c.ComentId == model.commentId);
            await checkLikeListAsync(model, user, comment);
            return RedirectToAction("CompanyProfile", "CompanyProfile", new { companyId });
        }
        
        private async Task checkLikeListAsync(CompanyProfileViewModel model, User user, Comments comment)
        {
            LikeList likeList = db.LikeList.FirstOrDefault(n => n.user == user && n.coment == comment);
            if(likeList == null){
                await addToLikeListAsync(model, user, comment);
            }
            else if(likeList.valueLike != model.like)
            {
                await replaceLikeListAsync(model, likeList, comment);
            }
        }

        private void likeCount(Comments comment, string like)
        {
            if(like == "like") { comment.like++; } else { comment.like--; };    //ToDo: make like !=0 after vote
        }

        private Company getCompanyById(int companyId)
        {
            return db.Company.Where(c => c.companyId == companyId).FirstOrDefault();
        }

        private async Task addToLikeListAsync(CompanyProfileViewModel model, User user, Comments comment)
        {
            LikeList like = new LikeList { coment = comment, user = user, valueLike = model.like };
            likeCount(comment, like.valueLike);
            await db.LikeList.AddAsync(like);
            await db.SaveChangesAsync();
        }

        private async Task replaceLikeListAsync(CompanyProfileViewModel model, LikeList likeList, Comments comment)
        {
            likeCount(comment, model.like);
            likeList.valueLike = model.like;
            await db.SaveChangesAsync();
        }
    }
}
