using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.Models
{
    public class UserDonate
    {
        [Key]
        public int rowId { get; set; }
        public User userId { get; set; }
        public Company companyId { get; set; }
        public double donate { get; set; }
    }
}
