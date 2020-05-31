using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.Models
{
    public class Company
    {
        [Key]
        public int companyId { get; set; }
        public string companyName { get; set; }
        public User creater { get; set; }
        public double totaldonate { get; set; }
        public double needDonate { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int rating { get; set; }
        public string about { get; set; }
        public DateTime lastUpdete { get; set; }
        public string companyImg { get; set; }

        public List<UserBonus> UserBonus { get; set; }
        public List<BonusList> BonusList { get; set; }
        public List<News> News { get; set; }
        public List<CompanyTag> CompanyTag { get; set; }
        public List<CompanyTheme> CompanyTheme { get; set; }
        public List<ResourcesLinks> ResourcesLinks { get; set; }
        public List<CompanyRating> CompanyRatings { get; set; }
        public List<Comments> Comments { get; set; }
        public List<UserDonate> userDonates { get; set; }

    }
}