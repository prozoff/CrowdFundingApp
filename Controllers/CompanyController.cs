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
        public IActionResult CreateCompany() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyViewModel model)
        {

            if (ModelState.IsValid)
            {
                string currentUser = User.Identity.Name;
                User user = await _userManager.FindByNameAsync(currentUser);
                Company company = new Company { companyName = model.companyName, creater = user, totaldonate = 0, needDonate = model.needDonate, startDate = DateTime.Now.ToString(), endDate = model.endDate, about = model.about};
                db.Company.Add(company);
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}
