﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.Models
{
    public class Comments
    {
        [Key]
        public int ComentId { get; set; }
        public Company company { get; set; }
        public User user { get; set; }
        public string comentText { get; set; }
        public string comentDate { get; set; }
        
        public List<LikeList> LikeLists { get; set; }
    }
}