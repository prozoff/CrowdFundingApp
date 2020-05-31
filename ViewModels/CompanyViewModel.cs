using CrowdFundingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.ViewModels
{
    public class CompanyViewModel
    {
        public List<Company> companies { get; set; }
        public List<CompanyTag> companyTags { get; set; }

        public CompanyViewModel()
        {
            companies = new List<Company>();
            companyTags = new List<CompanyTag>();
        }
    }
}
