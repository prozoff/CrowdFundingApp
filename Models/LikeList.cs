using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.Models
{
    public class LikeList
    {
        [Key]
        public int likeId { get; set; }
        public User user { get; set; }
        public Comments coment { get; set; }
    }
}
