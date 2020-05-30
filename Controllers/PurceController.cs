using CrowdFundingApp.Models;
using CrowdFundingApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.Controllers
{
    public class PurceController : Controller
    {
        ApplicationContext db;
        UserManager<User> _userManager;

        public PurceController(ApplicationContext context, UserManager<User> userManager)
        {
            db = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> indexAsync()
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            PurceViewModel model = new PurceViewModel { user = user };
            return View(model);
        }

        public async Task<IActionResult> addMoneyAsync(PurceViewModel model)
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            user.purce = user.purce + model.user.purce;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Profile", "Profile");
        }
    }
}
