using CrowdFundingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.ViewModels
{
    public class CompanyProfileViewModel
    {
        public int companyId { get; set; }
        public string companyName { get; set; }
        public string endDate { get; set; }
        public string about { get; set; }
        public string bonus { get; set; }
        public double bonusCost { get; set; }
        public string like { get; set; }
        public int commentId { get; set; }
        public int countLike { get; set; }
        public CompanyTheme themeName { get; set; }
        public Company companyProfile { get; set; }
        public List<BonusList> bonusList { get; set; }
        public List<Comments> comments { get; set; }
        public Comments comment { get; set; }
        public User currentUser { get; set; }

        public CompanyProfileViewModel()
        {
            bonusList = new List<BonusList>();
            comments = new List<Comments>();
        }
    }
}
