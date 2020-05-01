using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.ViewModels
{
    public class CreateCompanyViewModel
    {
        public int companyId { get; set; }
        public string companyName { get; set; }
        public string createrId { get; set; }
        public double totaldonate { get; set; }
        public double needDonate { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public double rating { get; set; }
        public string about { get; set; }
    }
}
