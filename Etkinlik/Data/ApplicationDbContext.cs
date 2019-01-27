using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Etkinlik.Models;

namespace Etkinlik.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<UserPostModel> UserPosts { get; set; }
        public DbSet<SurveyModel> Surveys { get; set; }
        public DbSet<SurveyChoiceModel> SurveyChoices { get; set; }
        public DbSet<UserSurveyModel> UserSurveys { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
