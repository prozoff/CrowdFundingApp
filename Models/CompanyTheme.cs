using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.Models
{
    public class CompanyTheme
    {
        [Key]
        public int rowId { get; set; }
        public Company company { get; set; }
        public ThemeList theme { get; set; }
    }
}