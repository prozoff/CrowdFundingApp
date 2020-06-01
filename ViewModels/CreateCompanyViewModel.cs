using CrowdFundingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.ViewModels
{
    public class CreateCompanyViewModel
    {
        public int theme { get; set; }
        public Company company { get; set; }
        public IList<string> tags { get; set; }
        public List<ThemeList> themeList { get; set; }
        public List<TagList> tagLists { get; set; }
        public ResourcesLinks resourcesLink { get; set; }
        
        public CreateCompanyViewModel()
        {
            tags = new List<string>();
            themeList = new List<ThemeList>();
            tagLists = new List<TagList>();
        }
    }
}
