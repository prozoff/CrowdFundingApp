using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.Models
{
    public class Comments
    {
        [Key]
        public int ComemntId { get; set; }
        public Company company { get; set; }
        public User user { get; set; }
        public string commentText { get; set; }
        public string commentDate { get; set; }
        public int like { get; set; }
        
        public List<LikeList> LikeLists { get; set; }
    }
}
