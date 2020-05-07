using CrowdFundingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.ViewModels
{
    public class CompanyProfileViewModel
    {
        internal int comapnyId;

        public int companyId { get; set; }
        public string companyName { get; set; }
        public double totalSum { get; set; }
        public double needSum { get; set; }
        public double rating { get; set; }
    }
}
