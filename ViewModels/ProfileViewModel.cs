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
        public List<Company> companies { get; set; }

        public ProfileViewModel()
        {
            companies = new List<Company>();
        }
    
    }
}
