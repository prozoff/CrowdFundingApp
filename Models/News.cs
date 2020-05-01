using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.Models
{
    public class News
    {
        [Key]
        public int newsId { get; set; }
        public Company company { get; set; }
        public string newsName { get; set; }
        public string newsText { get; set; }
        public string newsDate { get; set; }
        public string newsImg { get; set; }
    }
}
