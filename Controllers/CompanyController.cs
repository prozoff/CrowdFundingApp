using CrowdFundingApp.Models;
using CrowdFundingApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.Controllers
{

    //[Authorize(Roles = "Admin, User")]
    public class CompanyController : Controller
    {
        private ApplicationContext db;
        private UserManager<User> _userManager;

        public CompanyController(ApplicationContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            db = context;
        }

        public IActionResult Index() => View(db.Company.Include(u => u.creater).ToList());
        public IActionResult CreateCompany()
        {
            CreateCompanyViewModel model = new CreateCompanyViewModel
            {
                themeList = db.ThemeLists.ToList()
            };
            return View(model);
        }

        public IActionResult CompanyProfile(string companyId)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyViewModel model)
        {

            if (ModelState.IsValid)
            {
                string currentUser = User.Identity.Name;
                User user = await _userManager.FindByNameAsync(currentUser);
                Company company = new Company { companyName = model.companyName, creater = user, totaldonate = 0, needDonate = model.needDonate, startDate = DateTime.Now.ToString(), endDate = model.endDate, about = model.about };
                ThemeList theme = db.ThemeLists.Where(t => t.themeId == model.theme).FirstOrDefault();
                CompanyTheme companyTheme = new CompanyTheme { company = company, theme = theme };
                addTags(model, company);
                db.Company.Add(company);
                db.CompanyTheme.Add(companyTheme);
                db.SaveChanges();

                return RedirectToAction("CompanyProfile", "CompanyProfile", new { company.companyId });
            }
            return View(model);
        }

        private void addTags(CreateCompanyViewModel model, Company company)
        {
            foreach(string tags in model.tags)
            {
                if (db.TagLists.FirstOrDefault(t => t.tagName == tags) == null)
                {
                    TagList tag = new TagList { tagName = tags };
                    db.TagLists.Add(tag);
                }
            }
            addCompanyTag(model, company);
            db.SaveChanges();
        }

        private void addCompanyTag(CreateCompanyViewModel model, Company company)
        {
            CompanyTag companyTag;
            TagList tag;
            foreach(string tags in model.tags)
            {
                tag = db.TagLists.FirstOrDefault(t => t.tagName == tags);
                companyTag = new CompanyTag { company = company, tag = tag };
                db.CompanyTags.Add(companyTag);
            }
        }
    }
}
