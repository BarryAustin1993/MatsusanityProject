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
                new Administrator { Id = 1, FirstName = "Yuki", LastName = "Matsushima", UserId = USER_ID });

            builder.Entity<CalendarPlanWorkout>()
                    .HasKey(c => new { c.WorkoutId, c.WorkoutPlanId });

            builder.Entity<WorkoutPlan>()
                    .HasData(
                new WorkoutPlan { Id = 1, Name = "Gain Muscle", Description = "This plan is designed for you to gain muscle" },
                new WorkoutPlan { Id = 2, Name = "Lose Weight", Description = "This plan is designed for you to lose weight" },
                new WorkoutPlan { Id = 3, Name = "Get Fit", Description = "This plan is designed for you to get fit" });

            builder.Entity<Workout>()
                    .HasData(
                new Workout { Id = 1, WorkoutPlanId = 1, ExerciseOne = "Pull-Ups", RepsOne = "10", SetsOne = "3", WeightOne = "10", ExerciseTwo = "Push-Ups", RepsTwo = "10", SetsTwo = "3", WeightTwo = "10", ExerciseThree = "Mountains Climbers", RepsThree = "10", SetsThree = "3", WeightThree = "10", ExerciseFour = "Body Squats", RepsFour = "10", SetsFour = "3", WeightFour = "10", ExerciseFive = "Jumping Jacks", RepsFive = "10", SetsFive = "3", WeightFive = "10" },
                new Workout { Id = 2, WorkoutPlanId = 1, ExerciseOne = "Bench Press", RepsOne = "10", SetsOne = "3", WeightOne = "10", ExerciseTwo = "Bicep Curls", RepsTwo = "10", SetsTwo = "3", WeightTwo = "10", ExerciseThree = "OverHead Press", RepsThree = "10", SetsThree = "3", WeightThree = "10", ExerciseFour = "Skull Crushers", RepsFour = "10", SetsFour = "3", WeightFour = "10", ExerciseFive = "Shoulder Shrugs", RepsFive = "10", SetsFive = "3", WeightFive = "10" },
                new Workout { Id = 3, WorkoutPlanId = 1, ExerciseOne = "Squats", RepsOne = "10", SetsOne = "3", WeightOne = "10", ExerciseTwo = "Leg Press", RepsTwo = "10", SetsTwo = "3", WeightTwo = "10", ExerciseThree = "Leg Curl", RepsThree = "10", SetsThree = "3", WeightThree = "10", ExerciseFour = "Calf Raises", RepsFour = "10", SetsFour = "3", WeightFour = "10", ExerciseFive = "Box Jumps", RepsFive = "10", SetsFive = "3", WeightFive = "10" },
                new Workout { Id = 4, WorkoutPlanId = 2, ExerciseOne = "Pull-Ups", RepsOne = "10", SetsOne = "3", WeightOne = "10", ExerciseTwo = "Push-Ups", RepsTwo = "10", SetsTwo = "3", WeightTwo = "10", ExerciseThree = "Mountains Climbers", RepsThree = "10", SetsThree = "3", WeightThree = "10", ExerciseFour = "Body Squats", RepsFour = "10", SetsFour = "3", WeightFour = "10", ExerciseFive = "Jumping Jacks", RepsFive = "10", SetsFive = "3", WeightFive = "10" },
                new Workout { Id = 5, WorkoutPlanId = 2, ExerciseOne = "Bench Press", RepsOne = "10", SetsOne = "3", WeightOne = "10", ExerciseTwo = "Bicep Curls", RepsTwo = "10", SetsTwo = "3", WeightTwo = "10", ExerciseThree = "OverHead Press", RepsThree = "10", SetsThree = "3", WeightThree = "10", ExerciseFour = "Skull Crushers", RepsFour = "10", SetsFour = "3", WeightFour = "10", ExerciseFive = "Shoulder Shrugs", RepsFive = "10", SetsFive = "3", WeightFive = "10" },
                new Workout { Id = 6, WorkoutPlanId = 2, ExerciseOne = "Squats", RepsOne = "10", SetsOne = "3", WeightOne = "10", ExerciseTwo = "Leg Press", RepsTwo = "10", SetsTwo = "3", WeightTwo = "10", ExerciseThree = "Leg Curl", RepsThree = "10", SetsThree = "3", WeightThree = "10", ExerciseFour = "Calf Raises", RepsFour = "10", SetsFour = "3", WeightFour = "10", ExerciseFive = "Box Jumps", RepsFive = "10", SetsFive = "3", WeightFive = "10" },
                new Workout { Id = 7, WorkoutPlanId = 3, ExerciseOne = "Pull-Ups", RepsOne = "10", SetsOne = "3", WeightOne = "10", ExerciseTwo = "Push-Ups", RepsTwo = "10", SetsTwo = "3", WeightTwo = "10", ExerciseThree = "Mountains Climbers", RepsThree = "10", SetsThree = "3", WeightThree = "10", ExerciseFour = "Body Squats", RepsFour = "10", SetsFour = "3", WeightFour = "10", ExerciseFive = "Jumping Jacks", RepsFive = "10", SetsFive = "3", WeightFive = "10" },
                new Workout { Id = 8, WorkoutPlanId = 3, ExerciseOne = "Bench Press", RepsOne = "10", SetsOne = "3", WeightOne = "10", ExerciseTwo = "Bicep Curls", RepsTwo = "10", SetsTwo = "3", WeightTwo = "10", ExerciseThree = "OverHead Press", RepsThree = "10", SetsThree = "3", WeightThree = "10", ExerciseFour = "Skull Crushers", RepsFour = "10", SetsFour = "3", WeightFour = "10", ExerciseFive = "Shoulder Shrugs", RepsFive = "10", SetsFive = "3", WeightFive = "10" },
                new Workout { Id = 9, WorkoutPlanId = 3, ExerciseOne = "Squats", RepsOne = "10", SetsOne = "3", WeightOne = "10", ExerciseTwo = "Leg Press", RepsTwo = "10", SetsTwo = "3", WeightTwo = "10", ExerciseThree = "Leg Curl", RepsThree = "10", SetsThree = "3", WeightThree = "10", ExerciseFour = "Calf Raises", RepsFour = "10", SetsFour = "3", WeightFour = "10", ExerciseFive = "Box Jumps", RepsFive = "10", SetsFive = "3", WeightFive = "10" });

            builder.Entity<CalendarPlanWorkout>()
                    .HasData(
                new CalendarPlanWorkout { WorkoutPlanId = 1, WorkoutId = 1, Title = "Body", Description = "no weights, just body", Start = DateTime.Parse("2020-03-26"), AllDay = true, Url = "https://localhost:44366/clients/Workout/1" },
                new CalendarPlanWorkout { WorkoutPlanId = 1, WorkoutId = 2, Title = "Upper", Description = "Lower Body with equipment", Start = DateTime.Parse("2020-03-27"), AllDay = true, Url = "https://localhost:44366/clients/Workout/2" },
                new CalendarPlanWorkout { WorkoutPlanId = 1, WorkoutId = 3, Title = "Lower", Description = "Upper body with equipment", Start = DateTime.Parse("2020-03-28"), AllDay = true, Url = "https://localhost:44366/clients/Workout/3" },
                new CalendarPlanWorkout { WorkoutPlanId = 2, WorkoutId = 4, Title = "Body", Description = "no weights, just body", Start = DateTime.Parse("2020-03-26"), AllDay = true, Url = "https://localhost:44366/clients/Workout/4" },
                new CalendarPlanWorkout { WorkoutPlanId = 2, WorkoutId = 5, Title = "Upper", Description = "Lower Body with equipment", Start = DateTime.Parse("2020-03-27"), AllDay = true, Url = "https://localhost:44366/clients/Workout/5" },
                new CalendarPlanWorkout { WorkoutPlanId = 2, WorkoutId = 6, Title = "Lower", Description = "Upper body with equipment", Start = DateTime.Parse("2020-03-28"), AllDay = true, Url = "https://localhost:44366/clients/Workout/6" },
                new CalendarPlanWorkout { WorkoutPlanId = 3, WorkoutId = 7, Title = "Body", Description = "no weights, just body", Start = DateTime.Parse("2020-03-26"), AllDay = true, Url = "https://localhost:44366/clients/Workout/7" },
                new CalendarPlanWorkout { WorkoutPlanId = 3, WorkoutId = 8, Title = "Upper", Description = "Lower Body with equipment", Start = DateTime.Parse("2020-03-27"), AllDay = true, Url = "https://localhost:44366/clients/Workout/8" },
                new CalendarPlanWorkout { WorkoutPlanId = 3, WorkoutId = 9, Title = "Lower", Description = "Upper body with equipment", Start = DateTime.Parse("2020-03-28"), AllDay = true, Url = "https://localhost:44366/clients/Workout/9" });

            builder.Entity<PersonalTrainersClients>()
                    .HasKey(c => new { c.PersonalTrainerId, c.ClientId });
        }



        public DbSet<Matsusanity.Models.Administrator> Administrators { get; set; }

        public DbSet<Matsusanity.Models.Client> Clients { get; set; }

        public DbSet<Matsusanity.Models.PersonalTrainer> PersonalTrainers { get; set; }

        public DbSet<Matsusanity.Models.CalendarPlanWorkout> CalendarPlanWorkouts { get; set; }

        public DbSet<Matsusanity.Models.WorkoutPlan> WorkoutPlans { get; set; }

        public DbSet<Matsusanity.Models.PersonalTrainersClients> PersonalTrainersClients { get; set; }
        
        public DbSet<Matsusanity.Models.Workout> Workouts { get; set; }
        
        public DbSet<Matsusanity.Models.TrainerWeeklyAvailability> TrainerWeeklyAvailability { get; set; }
        
        public DbSet<Matsusanity.Models.InSessionRequest> InSessionRequest { get; set; }
    }
}
