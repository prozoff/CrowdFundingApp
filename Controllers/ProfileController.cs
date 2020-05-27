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
    public class ProfileController : Controller
    {
        ApplicationContext db;
        UserManager<User> _userManager;
        SignInManager<User> _signInManager;

        public ProfileController (ApplicationContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            db = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<ActionResult> ProfileAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ProfileViewModel model = new ProfileViewModel
            {
                companies = db.Company.Include(u => u.creater).Where(u => u.creater == user).ToList(),
                user = user,
            };
            return View(model);
        }

        public async Task<IActionResult> editLoginAsync(ProfileViewModel model, string userId)
        {
            User user = await _userManager.FindByIdAsync(userId);
            user.UserName = model.user.UserName;
            await _userManager.UpdateAsync(user);
            await reloginAsync(user);
            return RedirectToAction("Profile","Profile");
        }

        public async Task<IActionResult> changeAvatarAsync(ProfileViewModel model, string userId)
        {
            User user = await _userManager.FindByIdAsync(userId);
            user.profileImg = model.user.profileImg;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Profile", "Profile");
        }

        public async Task reloginAsync(User user)
        {
            await _signInManager.SignOutAsync();
            await _signInManager.SignInAsync(user, false);
        }
    }
}
