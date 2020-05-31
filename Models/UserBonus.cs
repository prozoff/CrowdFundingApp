using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.Models
{
    public class UserBonus
    {
        [Key]
        public int rowId { get; set; }
        public User user { get; set; }
        public BonusList bonus { get; set; }
        public Company company { get; set; }
    }
}
