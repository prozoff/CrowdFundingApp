using CrowdFundingApp.Models;
using CrowdFundingApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
            Company comapny = db.Company.Find(companyId);
            CompanyProfileViewModel model = new CompanyProfileViewModel
            {
                comapnyId = comapny.companyId,
                companyName = comapny.companyName,
                totalSum = comapny.totaldonate,
                needSum = comapny.needDonate,
                rating = comapny.rating

            };

            return View(model);
        }
    }
}
