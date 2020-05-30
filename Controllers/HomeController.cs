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
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

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
                lastUpdeteCompany = sortedCompanyUpdate(),
                ratedCompany = sortedCompanyRating(),
                tagLists = db.TagLists.ToList()
            };
            return View(model);
        }

        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        private List<Company> sortedCompanyUpdate()
        {
            IQueryable<Company> company = db.Company.Include(c => c.creater).OrderByDescending(u => u.lastUpdete);
            return company.ToList();
        }

        private List<Company> sortedCompanyRating()
        {
            IQueryable<Company> company = db.Company.Include(c => c.creater).OrderByDescending(r => r.rating);
            return company.ToList();
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

    }
}
