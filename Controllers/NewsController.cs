using CrowdFundingApp.Models;
using CrowdFundingApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.Controllers
{
    public class NewsController : Controller
    {
        ApplicationContext db;

        public NewsController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult createNews(int companyId)
        {
            NewsViewModel model = new NewsViewModel { company = companyId };
            return View(model);
        }


        public async Task<IActionResult> createAsync(NewsViewModel model, int companyId)
        {
            Company company = db.Company.FirstOrDefault(c => c.companyId == companyId);
            News news = new News { company = company, newsDate = DateTime.Now.ToString(), newsName = model.news.newsName, newsText = model.news.newsText};
            db.News.Add(news);
            await db.SaveChangesAsync();
            return RedirectToAction("CompanyProfile", "CompanyProfile", new { company.companyId });
        }

    }
}
