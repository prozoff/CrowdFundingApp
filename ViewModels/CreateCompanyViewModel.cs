using CrowdFundingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.ViewModels
{
    public class CreateCompanyViewModel
    {
        public string companyName { get; set; }
        public string createrId { get; set; }
        public double needDonate { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string about { get; set; }
        public int theme { get; set; }
        public List<ThemeList> themeList { get; set; }
        
        public CreateCompanyViewModel()
        {
            themeList = new List<ThemeList>();
        }
    }
}
