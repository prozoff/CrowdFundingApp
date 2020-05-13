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
        public List<Company> companyProfile { get; set; }

        public CompanyProfileViewModel()
        {
            companyProfile = new List<Company>();
        }
    }
}
