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
            string currentUser = User.Identity.Name;
            User user = await _userManager.FindByNameAsync(currentUser);
            Company company = new Company { 
                companyName = model.company.companyName, 
                creater = user, totaldonate = 0, 
                needDonate = model.company.needDonate, 
                startDate = DateTime.Now.ToString("dd.MM.yyyy"), 
                endDate = model.company.endDate, 
                about = model.company.about, 
                companyImg = model.company.companyImg, 
                lastUpdete = DateTime.Now.ToString("dd.MM.yyyy") 
            };
            ThemeList theme = db.ThemeLists.Where(t => t.themeId == model.theme).FirstOrDefault();
            CompanyTheme companyTheme = new CompanyTheme { company = company, theme = theme };
            addTags(model, company);
            db.Company.Add(company);
            db.CompanyTheme.Add(companyTheme);
            await db.SaveChangesAsync();

            return RedirectToAction("CompanyProfile", "CompanyProfile", new { company.companyId });
            
        }

        private void addTags(CreateCompanyViewModel model, Company company)
        {
            foreach(string tags in model.tags)
            {
                TagList tag;
                if (db.TagLists.FirstOrDefault(t => t.tagName == tags) == null)
                {
                    tag = createNewTag(tags);
                }
                else
                {
                    tag = findTag(tags);
                }
                addCompanyTag(tag, company);
            }
        }

        private void addCompanyTag(TagList tag, Company company)
        {
            CompanyTag companyTag = new CompanyTag { company = company, tag = tag };
            db.CompanyTags.Add(companyTag);
        }

        private TagList createNewTag(string tag)
        {
            TagList newTag = new TagList { tagName = tag };
            db.TagLists.Add(newTag);
            return newTag;
        }

        private TagList findTag(string tag)
        {
            return db.TagLists.FirstOrDefault(t => t.tagName == tag);
        }
    }
}
