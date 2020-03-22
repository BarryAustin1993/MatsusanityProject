using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Matsusanity.Models;

namespace Matsusanity.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            const string USER_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";

            const string ROLE_ID = "556b2822 - c6bf - 4d9b - a2f6 - 24353a19479d";

            builder.Entity<IdentityRole>()
                    .HasData(
                    new IdentityRole { Id = ROLE_ID, Name = "Administrator", NormalizedName = "ADMINISTRATOR" },
                    new IdentityRole { Name = "Personal Trainer", NormalizedName = "PERSONAL TRAINER" },
                    new IdentityRole { Name = "Client", NormalizedName = "CLIENT" });

            var hasher = new PasswordHasher<IdentityUser>();
            builder.Entity<IdentityUser>()
                    .HasData(
                    new IdentityUser { Id = USER_ID, UserName = "Matsusanity@gmail.com", NormalizedUserName = "MATSUSANITY@GMAIL.COM", Email = "Matsusanity@gmail.com", NormalizedEmail = "MATSUSANITY@GMAIL.COM", EmailConfirmed = true, PasswordHash = hasher.HashPassword(null, "Matsusanity!123"), SecurityStamp = string.Empty });

            builder.Entity<IdentityUserRole<string>>()
                    .HasData(
                new IdentityUserRole<string> { RoleId = ROLE_ID, UserId = USER_ID });

            builder.Entity<Administrator>()
                    .HasData(
                new Administrator {Id = 1, FirstName = "Yuki", LastName = "Matsushima", UserId = USER_ID });
        }

        public DbSet<Matsusanity.Models.Administrator> Administrator { get; set; }

        public DbSet<Matsusanity.Models.Client> Client { get; set; }

        public DbSet<Matsusanity.Models.PersonalTrainer> PersonalTrainer { get; set; }
    }
}
