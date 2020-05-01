using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.Models
{
    public class ResourcesLinks
    {
        [Key]
        public int resourceId { get; set; }
        public Company company { get; set; }
        public string type { get; set; }
        public string link { get; set; }

    }
}
