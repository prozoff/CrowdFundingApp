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
        public TagList tag { get; set; }
        

        public CompanyViewModel()
        {
            companies = new List<Company>();
        }
    }
}
