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
        public string startDate { get; set; }
        public string endDate { get; set; }
        public double rating { get; set; }
        public string about { get; set; }
        public string lastUpdete { get; set; }
        public string companyImg { get; set; }

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