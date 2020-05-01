using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.Models
{
    public class TagList
    {
        [Key]
        public int tagId { get; set; }
        public string tagName { get; set; }

        public List<CompanyTag> CompanyTags { get; set; }
    }
}
