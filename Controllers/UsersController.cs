using CrowdFundingApp.Models;
using CrowdFundingApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.Controllers
{
    public class UsersController : Controller
    {
        UserManager<User> _userManager;
        RoleManager<IdentityRole> _roleManager;
        SignInManager<User> _signInManager;

        public UsersController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index() => View(_userManager.Users.ToList());

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditRole(string userId)
        {
            // получаем пользователя
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(string userId, List<string> roles)
        {
            // получаем пользователя
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                // получаем все роли
                //var allRoles = _roleManager.Roles.ToList();
                // получаем список ролей, которые были добавлены
                var addedRoles = roles.Except(userRoles);
                // получаем роли, которые были удалены
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);

                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                return RedirectToAction("Index");
            }

            return NotFound();
        }


        [HttpPost]
        public async Task<ActionResult> Block(string[] selectedUsers)
        {
            bool checkSelf = false;
            var curUser = await _userManager.GetUserAsync(HttpContext.User);
            if (curUser != null && !curUser.isBlocked)
            {
                for (int i = 0; i < selectedUsers.Length; i++)
                {
                    User user = await _userManager.FindByIdAsync(selectedUsers[i]);
                    if (user != null)
                    {
                        user.isBlocked = true;
                        await _userManager.UpdateAsync(user);
                        if (curUser.Id == selectedUsers[i]) checkSelf = true;
                    }
                }
                if (checkSelf)
                {
                    await _signInManager.SignOutAsync();
                    return RedirectToAction("Login", "Account");
                }

            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<ActionResult> Unblock(string[] selectedUsers)
        {
            var curUser = await _userManager.GetUserAsync(HttpContext.User);
            if (curUser != null && !curUser.isBlocked)
            {
                for (int i = 0; i < selectedUsers.Length; i++)
                {
                    User user = await _userManager.FindByIdAsync(selectedUsers[i]);
                    user.isBlocked = false;
                    await _userManager.UpdateAsync(user);
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string[] selectedUsers)
        {
            bool checkSelf = false;
            var curUser = await _userManager.GetUserAsync(HttpContext.User);
            if (curUser != null && !curUser.isBlocked)
            {
                for (int i = 0; i < selectedUsers.Length; i++)
                {
                    User user = await _userManager.FindByIdAsync(selectedUsers[i]);
                    if (user != null)
                    {
                        IdentityResult result = await _userManager.DeleteAsync(user);
                        if (curUser.Id == selectedUsers[i]) checkSelf = true;
                    }

                }
                if (checkSelf)
                {
                    await _signInManager.SignOutAsync();
                    return RedirectToAction("Login", "Account");
                }

            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            return RedirectToAction("Index");
        }
    }
}
