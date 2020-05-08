using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Company> Company { get; set; }
        public DbSet<BonusList> BonusList { get; set; }
        public DbSet<UserBonus> UserBonus { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<TagList> TagLists { get; set; }
        public DbSet<ThemeList> ThemeLists { get; set; }
        public DbSet<CompanyTag> CompanyTags { get; set; }
        public DbSet<CompanyTheme> CompanyTheme { get; set; }
        public DbSet<CompanyRating> CompanyRatings { get; set; }
        public DbSet<ResourcesLinks> ResourcesLinks { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<LikeList> LikeList { get; set; }
        public DbSet<UserDonate> UserDonates { get; set; } 
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Admin", NormalizedName = "Admin"},
                new IdentityRole { Name = "User", NormalizedName = "User"});
        }
    }
}
