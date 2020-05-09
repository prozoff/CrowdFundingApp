using CrowdFundingApp.Models;
using CrowdFundingApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.Controllers
{
    public class ThemeController : Controller
    {
        private ApplicationContext db;

        public ThemeController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Index() => View(db.ThemeLists.ToList());
        public IActionResult CreateTheme() => View();


        public async Task<IActionResult> Create(ThemesViewModel model)
        {
            ThemeList themeList = new ThemeList { themeName = model.themeName };
            db.ThemeLists.Add(themeList);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
