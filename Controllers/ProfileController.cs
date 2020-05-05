using CrowdFundingApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.Controllers
{
    public class ProfileController : Controller
    {
        ApplicationContext db;
        UserManager<User> _userManager;

        public ProfileController (ApplicationContext context, UserManager<User> userManager)
        {
            db = context;
            _userManager = userManager;
        }


        public async Task<ActionResult> ProfileAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return View(db.Company.Include(u => u.creater).Where(u => u.creater == user).ToList());
        }
    }
}
