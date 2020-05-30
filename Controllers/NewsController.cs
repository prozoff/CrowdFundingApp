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
            News news = new News { company = company, newsDate = DateTime.Now.ToString(), newsName = model.news.newsName, newsText = model.news.newsText, newsImg = model.news.newsImg };
            company.lastUpdete = DateTime.Now.ToString("dd.MM.yyyy");
            db.News.Add(news);
            await db.SaveChangesAsync();
            return RedirectToAction("CompanyProfile", "CompanyProfile", new { company.companyId });
        }

        public IActionResult editNews(int newsId, int companyId)
        {
            Company company = db.Company.FirstOrDefault(c => c.companyId == companyId);
            News news = db.News.FirstOrDefault(n => n.newsId == newsId);
            NewsViewModel model = new NewsViewModel { news = news, company = companyId };
            return View(model); 
        }

        public async Task<IActionResult> saveEditNewsAsync(NewsViewModel model, int companyId, int newsId)
        {
            Company company = db.Company.FirstOrDefault(c => c.companyId == companyId);
            News news = db.News.FirstOrDefault(n => n.newsId == newsId);
            news.newsImg = model.news.newsImg;
            news.newsName = model.news.newsName;
            news.newsText = model.news.newsText;
            company.lastUpdete = DateTime.Now.ToString("dd.MM.yyyy");
            await db.SaveChangesAsync();
            return RedirectToAction("CompanyProfile", "CompanyProfile", new { companyId });
        }

        public async Task<IActionResult> deleteNewsAsync(int newsId, int companyId)
        {
            News news = db.News.FirstOrDefault(n => n.newsId == newsId);
            db.News.Remove(news);
            await db.SaveChangesAsync();
            return RedirectToAction("CompanyProfile", "CompanyProfile", new { companyId });
        }
    }
}
