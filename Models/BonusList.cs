using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.Models
{
    public class BonusList
    {
        [Key]
        public int bonusId { get; set; }
        public string bonusName { get; set; }
        public Company company { get; set; }
        public double bonusCost { get; set; }
        public string aboutBonus { get; set; }
        public List<UserBonus> UserBonus { get; set; }
    }
}
