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
            CompanyProfileViewModel model = new CompanyProfileViewModel
            {
                companyProfile = db.Company.Where(c => c.companyId == companyId).ToList()
            };

            return View(model);
        }

        public IActionResult EditCompany(int companyId)
        {
            CompanyProfileViewModel model = new CompanyProfileViewModel
            {
                companyProfile = db.Company.Where(c => c.companyId == companyId).ToList()
            };

            return View(model);
        }

        public async Task<IActionResult> Save(CompanyProfileViewModel model, int companyId)
        {
            Company company = db.Company.Where(c => c.companyId == companyId).FirstOrDefault();
            company.companyName = model.companyName;
            db.SaveChanges();
            return RedirectToAction("CompanyProfile", "CompanyProfile", new { company.companyId });
        }
    }
}
