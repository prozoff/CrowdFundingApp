using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.Models
{
    public class User : IdentityUser
    {
        public bool isBlocked { get; set; }
        public double purce { get; set; }
        public string createDate { get; set; }
        public string profileImg { get; set; }

        public List<Company> Company { get; set; }
        public List<UserBonus> UserBonus { get; set; }
        public List<CompanyRating> CompanyRatings { get; set; }
        public List<Comments> Comments { get; set; }
        public List<LikeList> LikeLists { get; set; }
        public List<UserDonate> userDonates { get; set; }
    }

}
