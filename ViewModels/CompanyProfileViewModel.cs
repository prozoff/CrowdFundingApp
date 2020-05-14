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
        public string bonusCost { get; set; }
        public List<Company> companyProfile { get; set; }

        public CompanyProfileViewModel()
        {
            companyProfile = new List<Company>();
        }
    }
}
