using CrowdFundingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.ViewModels
{
    public class ProfileViewModel
    {
        public User user { get; set; }
        public Company company { get; set; }
        public List<Company> companies { get; set; }
        public List<UserBonus> userBonus { get; set; }

        public ProfileViewModel()
        {
            userBonus = new List<UserBonus>();
            companies = new List<Company>();
        }
    
    }
}
