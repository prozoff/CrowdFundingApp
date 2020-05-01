using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.Models
{
    public class ThemeList
    {
        [Key]
        public int themeId { get; set; }
        public string themeName { get; set; }
        public List<CompanyTheme> CompanyTheme { get; set; }
    }
}
