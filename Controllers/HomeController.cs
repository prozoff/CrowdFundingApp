using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CrowdFundingApp.Models;
using Microsoft.EntityFrameworkCore;
using CrowdFundingApp.ViewModels;

namespace CrowdFundingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationContext db;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            db = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel
            {
                lastUpdeteCompany = db.Company.Include(v => v.creater).ToList(),
                ratedCompany = db.Company.Include(v => v.creater).ToList()
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult toCompany()
        {
            return RedirectToAction("Index", "Company");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult toUsers()
        {
            return RedirectToAction("Index", "Users");
        }
    }
}
