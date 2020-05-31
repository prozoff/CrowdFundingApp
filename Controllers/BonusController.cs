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
    public class BonusController : Controller
    {
        ApplicationContext db;
        UserManager<User> _userManager;

        public BonusController(ApplicationContext context, UserManager<User> userManager)
        {
            db = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> supportAsync(CompanyProfileViewModel model, int companyId)
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            BonusList bonus = db.BonusList.FirstOrDefault(b => b.bonusId == model.bonus.bonusId);
            if (await checkPurceAsync(user, bonus))
            {
                addBonusToUser(user, bonus, companyId);
                addToUserDonate(user, bonus, companyId);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("CompanyProfile", "CompanyProfile", new { companyId });
        }

        private void addToUserDonate(User user, BonusList bonus, int companyId)
        {
            Company company = getCompanyById(companyId);
            if(db.UserDonates.FirstOrDefault(u => u.userId == user) == null)
            {
                UserDonate userDonate = new UserDonate { userId = user, companyId = company, donate = bonus.bonusCost };
                db.UserDonates.Add(userDonate);
            }
            else
            {
                UserDonate userDonate = db.UserDonates.FirstOrDefault(u => u.userId == user);
                userDonate.donate += bonus.bonusCost;
            }
        }

        private async Task<bool> checkPurceAsync(User user, BonusList bonus)
        {
            if ((user.purce - bonus.bonusCost) >= 0)
            {
                user.purce -= bonus.bonusCost;
                await _userManager.UpdateAsync(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void addBonusToUser(User user, BonusList bonus, int companyId)
        {
            Company company = getCompanyById(companyId);
            UserBonus userBonus = new UserBonus { user = user, bonus = bonus, company = company };
            company.totaldonate += bonus.bonusCost;
            db.UserBonus.Add(userBonus);
        }

        

        private Company getCompanyById(int companyId)
        {
            return db.Company.Where(c => c.companyId == companyId).FirstOrDefault();
        }
    }
}
