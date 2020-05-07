using CrowdFundingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.ViewModels
{
    public class HomeViewModel
    {
        public List<Company> lastUpdeteCompany { get; set; }
        public List<Company> ratedCompany { get; set; }

        public HomeViewModel()
        {
            lastUpdeteCompany = new List<Company>();
            ratedCompany = new List<Company>();
        }
    }
}
