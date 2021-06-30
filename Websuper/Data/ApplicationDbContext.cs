using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Websuper.Models;

namespace Websuper.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<OneBlog> OneBlogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ConsultNow> ConsultNows { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<CountDown> CountDowns { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<SubAdditionaly> SubAdditionalies { get; set; }
        public DbSet<Support> Supports { get; set; }
        public DbSet<WebsuperUser> WebsuperUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // This needs to go before the other rules!

            modelBuilder.Entity<WebsuperUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        }

        public DbSet<Websuper.Models.Additionaly> Additionaly { get; set; }
    }
}
