using CrowdFundingApp.Models;
using CrowdFundingApp.ViewModels;
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

        public CompanyProfileController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult CompanyProfile(int companyId)
        {
            Company company = db.Company.Include(b => b.BonusList).Where(c => c.companyId == companyId).FirstOrDefault();
            CompanyTheme companyTheme = db.CompanyTheme.Include(t => t.theme).Where(t => t.company == company).FirstOrDefault();
            CompanyProfileViewModel model = new CompanyProfileViewModel
            {
                companyProfile = company,
                themeName = companyTheme
            };

            return View(model);
        }

        public IActionResult EditCompany(int companyId)
        {
            Company company = db.Company.Where(c => c.companyId == companyId).FirstOrDefault();
            CompanyProfileViewModel model = new CompanyProfileViewModel
            {
                companyProfile = db.Company.Where(c => c.companyId == companyId).FirstOrDefault(),
                bonusList = db.BonusList.Include(v => v.company).Where(c => c.company == company).ToList()
            };

            return View(model);
        }

        public IActionResult Save(CompanyProfileViewModel model, int companyId)
        {
            Company company = db.Company.Where(c => c.companyId == companyId).FirstOrDefault();
            company.companyName = model.companyName;
            db.SaveChanges();
            return RedirectToAction("CompanyProfile", "CompanyProfile", new { company.companyId });
        }

        public async Task<IActionResult> saveBonusAsync(CompanyProfileViewModel model, int companyId)
        {
            Company company = db.Company.Where(c => c.companyId == companyId).FirstOrDefault();
            BonusList bonusList = new BonusList { bonusName = model.bonus, bonusCost = model.bonusCost, company = company };
            db.BonusList.Add(bonusList);
            await db.SaveChangesAsync();
            return RedirectToAction("EditCompany", "CompanyProfile", new { company.companyId });
        }

        public IActionResult addBonus(int companyId)
        {
            Company company = db.Company.Where(c => c.companyId == companyId).FirstOrDefault();
            CompanyProfileViewModel model = new CompanyProfileViewModel
            {
                companyProfile = company
            };
            return View(model);
        }

        public IActionResult deleteCompany(int companyId)
        {
            Company company = db.Company.Include(t => t.CompanyTheme).Include(b => b.BonusList).Where(c => c.companyId == companyId).FirstOrDefault(); //bad idea but it worked (check caskade delete)
            db.Company.Remove(company);
            db.SaveChanges();
            return RedirectToAction("index", "Home");
        }
    }
}
