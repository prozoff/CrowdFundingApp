using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.Models
{
    public class CompanyRating
    {
        [Key]
        public int voteId { get; set; }
        public User user { get; set; }
        public Company company { get; set; }
        public int rating { get; set; }
    }
}
