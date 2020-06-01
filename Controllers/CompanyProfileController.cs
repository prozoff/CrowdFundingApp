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
    public class CompanyProfileController : Controller
    {
        ApplicationContext db;
        UserManager<User> _userManager;

        public CompanyProfileController(ApplicationContext context, UserManager<User> userManager)
        {
            db = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> CompanyProfileAsync(int companyId)
        {
            Company company = db.Company.Include(b => b.BonusList).Include(u => u.creater).Include(n => n.News).Where(c => c.companyId == companyId).FirstOrDefault();
            User user = await _userManager.GetUserAsync(HttpContext.User);
            CompanyProfileViewModel model = new CompanyProfileViewModel
            {
                companyProfile = company,
                themeName = db.CompanyTheme.Include(t => t.theme).Where(t => t.company == company).FirstOrDefault(),
                comments = db.Comments.Include(u => u.user).Include(l => l.LikeLists).Where(c => c.company == company).ToList(),
                currentUser = user,
                companyRating = userRatingCompany(user, company),
                resourcesVidio = db.ResourcesLinks.FirstOrDefault(c => c.company == company && c.type == "vidio"),
                resourcesImg = db.ResourcesLinks.Where(c => c.company == getCompanyById(companyId) && c.type == "img").Take(4).ToList()
            };

            return View(model);
        }

        private CompanyRating userRatingCompany(User user, Company company)
        {
            CompanyRating companyRating = db.CompanyRatings.FirstOrDefault(r => r.user == user && r.company == company);
            if (companyRating == null) 
            {
                companyRating = new CompanyRating { rating = 0 };
            }
            return companyRating;
        }

        public async Task<IActionResult> addCommentAsync(CompanyProfileViewModel model, int companyId)
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            Company company = getCompanyById(companyId);
            Comments comment = new Comments { company = company, user = user, commentText = model.comment.commentText, commentDate = DateTime.Now, like = 0 };
            db.Comments.Add(comment);
            await db.SaveChangesAsync();
            return RedirectToAction("CompanyProfile", "CompanyProfile", new { companyId });
        }


        public IActionResult EditCompany(int companyId)
        {
            Company company = getCompanyById(companyId);
            CompanyProfileViewModel model = new CompanyProfileViewModel
            {
                companyProfile = db.Company.Where(c => c.companyId == companyId).FirstOrDefault(),
                bonusList = db.BonusList.Include(v => v.company).Where(c => c.company == company).ToList()
            };

            return View(model);
        }

        public IActionResult toGallery(int companyId)
        {
            CompanyProfileViewModel model = new CompanyProfileViewModel
            {
                companyProfile = getCompanyById(companyId),
                resourcesImg = db.ResourcesLinks.Where(c => c.company == getCompanyById(companyId) && c.type == "img").ToList()
            };
            return View("Gallery", model);
        }

        public async Task<IActionResult> addImageAsync(CompanyProfileViewModel model, int companyId)
        {
            Company company = getCompanyById(companyId);
            ResourcesLinks resourcesLinks;
            foreach (ResourcesLinks resources in model.resourcesImg)
            {
                resourcesLinks = new ResourcesLinks { link = resources.link, company = company, type = "img" };
                db.ResourcesLinks.Add(resourcesLinks);
            }
            await db.SaveChangesAsync();
            return RedirectToAction("CompanyProfile", "CompanyProfile", new { companyId });
        }

        public IActionResult Save(CompanyProfileViewModel model, int companyId)
        {
            Company company = getCompanyById(companyId);
            addVidio(model, company);
            company.companyName = model.companyProfile.companyName;
            company.about = model.companyProfile.about;
            company.companyImg = model.companyProfile.companyImg;
            company.lastUpdete = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("CompanyProfile", "CompanyProfile", new { company.companyId });
        }

        private void addVidio(CompanyProfileViewModel model, Company company)
        {
            ResourcesLinks resourcesLink = db.ResourcesLinks.FirstOrDefault(c => c.company == company);
            string editedLink = editLink(model.resourcesVidio.link);
            if (editedLink == "") { return; };
            if(resourcesLink == null)
            {
                resourcesLink = new ResourcesLinks { company = company, link = editedLink, type = "vidio" };
                db.ResourcesLinks.Add(resourcesLink);
            }
            else
            {
                resourcesLink.link = editedLink;
            }
        }

        private string editLink(string link)
        {
            if (link != null)
            {
                if (link.Contains("/watch?v=") || link.Contains("youtu.be"))
                {
                    int index = link.IndexOf("/watch?v=");
                    link = link.Substring(index + 9);
                    link = "https://www.youtube.com/embed/" + link;
                    return link;
                }
            }
            return "";
        }

        public async Task<IActionResult> saveBonusAsync(CompanyProfileViewModel model, int companyId)
        {
            Company company = getCompanyById(companyId);
            BonusList bonusList = new BonusList { bonusName = model.bonus.bonusName, bonusCost = model.bonus.bonusCost, company = company, aboutBonus = model.bonus.aboutBonus };
            db.BonusList.Add(bonusList);
            await db.SaveChangesAsync();
            return RedirectToAction("EditCompany", "CompanyProfile", new { company.companyId });
        }

        public IActionResult addBonus(int companyId)
        {
            Company company = getCompanyById(companyId);
            CompanyProfileViewModel model = new CompanyProfileViewModel { companyProfile = company };
            return View(model);
        }

        public IActionResult editBonus(int companyId, int bonusId)
        {
            Company company = getCompanyById(companyId);
            BonusList bonus = db.BonusList.FirstOrDefault(b => b.bonusId == bonusId);
            CompanyProfileViewModel model = new CompanyProfileViewModel { companyProfile = company, bonus = bonus };
            return View(model);
        }

        public async Task<IActionResult> saveEditedBonusAsync(CompanyProfileViewModel model, int companyId, int bonusId)
        {
            Company company = getCompanyById(companyId);
            BonusList bonus = db.BonusList.FirstOrDefault(b => b.bonusId == bonusId);
            bonus.bonusName = model.bonus.bonusName;
            bonus.bonusCost = model.bonus.bonusCost;
            bonus.aboutBonus = model.bonus.aboutBonus;
            await db.SaveChangesAsync();
            return RedirectToAction("EditCompany", "CompanyProfile", new { company.companyId });
        }

        public IActionResult deleteCompany(int companyId)
        {
            Company company = db.Company.Include(t => t.CompanyTheme)
                .Include(c => c.Comments)
                .Include(t => t.CompanyTag)
                .Include(n => n.News)
                .Include(b => b.BonusList)
                .Include(u => u.UserBonus)
                .Include(u => u.userDonates)
                .Include(r => r.ResourcesLinks)
                .Where(c => c.companyId == companyId)
                .FirstOrDefault();
            removeBonuses(company);
            removeCompanyTags(company);
            db.Company.Remove(company);
            db.SaveChanges();
            return RedirectToAction("index", "Home");
        }

        private void removeCompanyTags(Company company)
        {
            List<CompanyTag> companyTags = db.CompanyTags.Where(c => c.company == company || c.company == null).ToList();
            foreach(CompanyTag companyTag in companyTags)
            {
                db.CompanyTags.Remove(companyTag);
            }
        }

        private void removeBonuses(Company company)
        {
            List<UserBonus> userBonuses = db.UserBonus.Where(c => c.company == company || c.company == null).ToList();
            foreach(UserBonus userBonus in userBonuses)
            {
                db.UserBonus.Remove(userBonus);
            }
        }

        public async Task<IActionResult> likeAsync(CompanyProfileViewModel model, int companyId)
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            Comments comment = db.Comments.FirstOrDefault(c => c.ComemntId == model.commentId);
            await checkLikeListAsync(model, user, comment);
            return RedirectToAction("CompanyProfile", "CompanyProfile", new { companyId });
        }

        private async Task checkLikeListAsync(CompanyProfileViewModel model, User user, Comments comment)
        {
            LikeList likeList = db.LikeList.FirstOrDefault(n => n.user == user && n.coment == comment);
            if (likeList == null)
            {
                await addToLikeListAsync(model, user, comment);
            }
            else if (likeList.valueLike != model.like)
            {
                await replaceLikeListAsync(model, likeList, comment);
            }
        }

        private void likeCount(Comments comment, string like)
        {
            if (like == "like") { comment.like++; } else { comment.like--; };    //ToDo: make like !=0 after vote
        }

        private async Task addToLikeListAsync(CompanyProfileViewModel model, User user, Comments comment)
        {
            LikeList like = new LikeList { coment = comment, user = user, valueLike = model.like };
            likeCount(comment, like.valueLike);
            await db.LikeList.AddAsync(like);
            await db.SaveChangesAsync();
        }

        private async Task replaceLikeListAsync(CompanyProfileViewModel model, LikeList likeList, Comments comment)
        {
            likeCount(comment, model.like);
            likeList.valueLike = model.like;
            await db.SaveChangesAsync();
        }


        public async Task<IActionResult> voteRatingAsync(CompanyProfileViewModel model, int companyId)
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            Company company = getCompanyById(companyId);
            addRatingToCompany(model.companyProfile.rating, company, user);
            await db.SaveChangesAsync();
            return RedirectToAction("CompanyProfile", "CompanyProfile", new { companyId });
        }

        private void addRatingToCompany(int rating, Company company, User user)
        {
            if (db.CompanyRatings.FirstOrDefault(c => c.company == company && c.user == user) == null)
            {
                addVote(rating, company, user);
            }
            else
            {
                replaceVote(rating, company, user);
            }
        }

        private void replaceVote(int rating, Company company, User user)
        {
            CompanyRating companyRating = db.CompanyRatings.FirstOrDefault(c => c.company == company && c.user == user);
            companyRating.rating = rating;
            reratingCompany(company, rating, companyRating);
        }


        private void addVote(int rating, Company company, User user)
        {
            CompanyRating companyRating = new CompanyRating { company = company, user = user, rating = rating };
            reratingCompany(company, rating, companyRating);
            db.CompanyRatings.AddAsync(companyRating);
        }

        private void reratingCompany(Company company, int rating, CompanyRating companyRating)
        {
            if (db.CompanyRatings.Where(c => c.company == company).Count() == 0)
            {
                company.rating = rating;
            }
            else
            {
                company.rating = avgRating(company, companyRating);
            }
        }

        private int avgRating(Company company, CompanyRating newCompanyRating)
        {
            int avgCount = 0;
            List<CompanyRating> companyRatingsList = db.CompanyRatings.Where(c => c.company == company).ToList();
            companyRatingsList.Add(newCompanyRating);
            foreach (CompanyRating companyRating in companyRatingsList)
            {
                if(companyRating.user == newCompanyRating.user && companyRating.company == newCompanyRating.company)
                {
                    companyRating.rating = newCompanyRating.rating;
                }
                avgCount += companyRating.rating;
            }
            return avgCount / companyRatingsList.Count;   //ToDo rounded
        }

        private Company getCompanyById(int companyId)
        {
            return db.Company.Where(c => c.companyId == companyId).Include(u => u.creater).FirstOrDefault();
        }
    }
}
