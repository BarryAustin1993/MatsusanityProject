﻿// <auto-generated />
using System;
using Matsusanity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Matsusanity.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200330180542_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Matsusanity.Models.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Administrator");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Yuki",
                            LastName = "Matsushima",
                            UserId = "a18be9c0-aa65-4af8-bd17-00bd9344e575"
                        });
                });

            modelBuilder.Entity("Matsusanity.Models.CalendarPlanWorkout", b =>
                {
                    b.Property<int>("WorkoutId")
                        .HasColumnType("int");

                    b.Property<int>("WorkoutPlanId")
                        .HasColumnType("int");

                    b.Property<bool>("AllDay")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WorkoutId", "WorkoutPlanId");

                    b.ToTable("CalendarPlanWorkouts");

                    b.HasData(
                        new
                        {
                            WorkoutId = 1,
                            WorkoutPlanId = 1,
                            AllDay = true,
                            Description = "no weights, just body",
                            Start = new DateTime(2020, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Body"
                        },
                        new
                        {
                            WorkoutId = 2,
                            WorkoutPlanId = 1,
                            AllDay = true,
                            Description = "Lower Body with equipment",
                            Start = new DateTime(2020, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Upper"
                        },
                        new
                        {
                            WorkoutId = 3,
                            WorkoutPlanId = 1,
                            AllDay = true,
                            Description = "Upper body with equipment",
                            Start = new DateTime(2020, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Lower"
                        },
                        new
                        {
                            WorkoutId = 4,
                            WorkoutPlanId = 2,
                            AllDay = true,
                            Description = "no weights, just body",
                            Start = new DateTime(2020, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Body"
                        },
                        new
                        {
                            WorkoutId = 5,
                            WorkoutPlanId = 2,
                            AllDay = true,
                            Description = "Lower Body with equipment",
                            Start = new DateTime(2020, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Upper"
                        },
                        new
                        {
                            WorkoutId = 6,
                            WorkoutPlanId = 2,
                            AllDay = true,
                            Description = "Upper body with equipment",
                            Start = new DateTime(2020, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Lower"
                        },
                        new
                        {
                            WorkoutId = 7,
                            WorkoutPlanId = 3,
                            AllDay = true,
                            Description = "no weights, just body",
                            Start = new DateTime(2020, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Body"
                        },
                        new
                        {
                            WorkoutId = 8,
                            WorkoutPlanId = 3,
                            AllDay = true,
                            Description = "Lower Body with equipment",
                            Start = new DateTime(2020, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Upper"
                        },
                        new
                        {
                            WorkoutId = 9,
                            WorkoutPlanId = 3,
                            AllDay = true,
                            Description = "Upper body with equipment",
                            Start = new DateTime(2020, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Lower"
                        });
                });

            modelBuilder.Entity("Matsusanity.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("WorkoutPlanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkoutPlanId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Matsusanity.Models.PersonalTrainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InPersonSessions")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PersonalTrainers");
                });

            modelBuilder.Entity("Matsusanity.Models.PersonalTrainersClients", b =>
                {
                    b.Property<int>("PersonalTrainerId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.HasKey("PersonalTrainerId", "ClientId");

                    b.ToTable("PersonalTrainersClients");
                });

            modelBuilder.Entity("Matsusanity.Models.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ExerciseFive")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExerciseFour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExerciseOne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExerciseThree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExerciseTwo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RepsFive")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RepsFour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RepsOne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RepsThree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RepsTwo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SetsFive")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SetsFour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SetsOne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SetsThree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SetsTwo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WeightFive")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WeightFour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WeightOne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WeightThree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WeightTwo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WorkoutPlanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutPlanId");

                    b.ToTable("Workouts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ExerciseFive = "Jumping Jacks",
                            ExerciseFour = "Body Squats",
                            ExerciseOne = "Pull-Ups",
                            ExerciseThree = "Mountains Climbers",
                            ExerciseTwo = "Push-Ups",
                            RepsFive = "10",
                            RepsFour = "10",
                            RepsOne = "10",
                            RepsThree = "10",
                            RepsTwo = "10",
                            SetsFive = "3",
                            SetsFour = "3",
                            SetsOne = "3",
                            SetsThree = "3",
                            SetsTwo = "3",
                            WeightFive = "10",
                            WeightFour = "10",
                            WeightOne = "10",
                            WeightThree = "10",
                            WeightTwo = "10",
                            WorkoutPlanId = 1
                        },
                        new
                        {
                            Id = 2,
                            ExerciseFive = "Shoulder Shrugs",
                            ExerciseFour = "Skull Crushers",
                            ExerciseOne = "Bench Press",
                            ExerciseThree = "OverHead Press",
                            ExerciseTwo = "Bicep Curls",
                            RepsFive = "10",
                            RepsFour = "10",
                            RepsOne = "10",
                            RepsThree = "10",
                            RepsTwo = "10",
                            SetsFive = "3",
                            SetsFour = "3",
                            SetsOne = "3",
                            SetsThree = "3",
                            SetsTwo = "3",
                            WeightFive = "10",
                            WeightFour = "10",
                            WeightOne = "10",
                            WeightThree = "10",
                            WeightTwo = "10",
                            WorkoutPlanId = 1
                        },
                        new
                        {
                            Id = 3,
                            ExerciseFive = "Box Jumps",
                            ExerciseFour = "Calf Raises",
                            ExerciseOne = "Squats",
                            ExerciseThree = "Leg Curl",
                            ExerciseTwo = "Leg Press",
                            RepsFive = "10",
                            RepsFour = "10",
                            RepsOne = "10",
                            RepsThree = "10",
                            RepsTwo = "10",
                            SetsFive = "3",
                            SetsFour = "3",
                            SetsOne = "3",
                            SetsThree = "3",
                            SetsTwo = "3",
                            WeightFive = "10",
                            WeightFour = "10",
                            WeightOne = "10",
                            WeightThree = "10",
                            WeightTwo = "10",
                            WorkoutPlanId = 1
                        },
                        new
                        {
                            Id = 4,
                            ExerciseFive = "Jumping Jacks",
                            ExerciseFour = "Body Squats",
                            ExerciseOne = "Pull-Ups",
                            ExerciseThree = "Mountains Climbers",
                            ExerciseTwo = "Push-Ups",
                            RepsFive = "10",
                            RepsFour = "10",
                            RepsOne = "10",
                            RepsThree = "10",
                            RepsTwo = "10",
                            SetsFive = "3",
                            SetsFour = "3",
                            SetsOne = "3",
                            SetsThree = "3",
                            SetsTwo = "3",
                            WeightFive = "10",
                            WeightFour = "10",
                            WeightOne = "10",
                            WeightThree = "10",
                            WeightTwo = "10",
                            WorkoutPlanId = 2
                        },
                        new
                        {
                            Id = 5,
                            ExerciseFive = "Shoulder Shrugs",
                            ExerciseFour = "Skull Crushers",
                            ExerciseOne = "Bench Press",
                            ExerciseThree = "OverHead Press",
                            ExerciseTwo = "Bicep Curls",
                            RepsFive = "10",
                            RepsFour = "10",
                            RepsOne = "10",
                            RepsThree = "10",
                            RepsTwo = "10",
                            SetsFive = "3",
                            SetsFour = "3",
                            SetsOne = "3",
                            SetsThree = "3",
                            SetsTwo = "3",
                            WeightFive = "10",
                            WeightFour = "10",
                            WeightOne = "10",
                            WeightThree = "10",
                            WeightTwo = "10",
                            WorkoutPlanId = 2
                        },
                        new
                        {
                            Id = 6,
                            ExerciseFive = "Box Jumps",
                            ExerciseFour = "Calf Raises",
                            ExerciseOne = "Squats",
                            ExerciseThree = "Leg Curl",
                            ExerciseTwo = "Leg Press",
                            RepsFive = "10",
                            RepsFour = "10",
                            RepsOne = "10",
                            RepsThree = "10",
                            RepsTwo = "10",
                            SetsFive = "3",
                            SetsFour = "3",
                            SetsOne = "3",
                            SetsThree = "3",
                            SetsTwo = "3",
                            WeightFive = "10",
                            WeightFour = "10",
                            WeightOne = "10",
                            WeightThree = "10",
                            WeightTwo = "10",
                            WorkoutPlanId = 2
                        },
                        new
                        {
                            Id = 7,
                            ExerciseFive = "Jumping Jacks",
                            ExerciseFour = "Body Squats",
                            ExerciseOne = "Pull-Ups",
                            ExerciseThree = "Mountains Climbers",
                            ExerciseTwo = "Push-Ups",
                            RepsFive = "10",
                            RepsFour = "10",
                            RepsOne = "10",
                            RepsThree = "10",
                            RepsTwo = "10",
                            SetsFive = "3",
                            SetsFour = "3",
                            SetsOne = "3",
                            SetsThree = "3",
                            SetsTwo = "3",
                            WeightFive = "10",
                            WeightFour = "10",
                            WeightOne = "10",
                            WeightThree = "10",
                            WeightTwo = "10",
                            WorkoutPlanId = 3
                        },
                        new
                        {
                            Id = 8,
                            ExerciseFive = "Shoulder Shrugs",
                            ExerciseFour = "Skull Crushers",
                            ExerciseOne = "Bench Press",
                            ExerciseThree = "OverHead Press",
                            ExerciseTwo = "Bicep Curls",
                            RepsFive = "10",
                            RepsFour = "10",
                            RepsOne = "10",
                            RepsThree = "10",
                            RepsTwo = "10",
                            SetsFive = "3",
                            SetsFour = "3",
                            SetsOne = "3",
                            SetsThree = "3",
                            SetsTwo = "3",
                            WeightFive = "10",
                            WeightFour = "10",
                            WeightOne = "10",
                            WeightThree = "10",
                            WeightTwo = "10",
                            WorkoutPlanId = 3
                        },
                        new
                        {
                            Id = 9,
                            ExerciseFive = "Box Jumps",
                            ExerciseFour = "Calf Raises",
                            ExerciseOne = "Squats",
                            ExerciseThree = "Leg Curl",
                            ExerciseTwo = "Leg Press",
                            RepsFive = "10",
                            RepsFour = "10",
                            RepsOne = "10",
                            RepsThree = "10",
                            RepsTwo = "10",
                            SetsFive = "3",
                            SetsFour = "3",
                            SetsOne = "3",
                            SetsThree = "3",
                            SetsTwo = "3",
                            WeightFive = "10",
                            WeightFour = "10",
                            WeightOne = "10",
                            WeightThree = "10",
                            WeightTwo = "10",
                            WorkoutPlanId = 3
                        });
                });

            modelBuilder.Entity("Matsusanity.Models.WorkoutPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("WorkoutPlans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "This plan is designed for you to gain muscle",
                            Name = "Gain Muscle",
                            UserId = "a18be9c0-aa65-4af8-bd17-00bd9344e575"
                        },
                        new
                        {
                            Id = 2,
                            Description = "This plan is designed for you to lose weight",
                            Name = "Lose Weight",
                            UserId = "a18be9c0-aa65-4af8-bd17-00bd9344e575"
                        },
                        new
                        {
                            Id = 3,
                            Description = "This plan is designed for you to get fit",
                            Name = "Get Fit",
                            UserId = "a18be9c0-aa65-4af8-bd17-00bd9344e575"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "556b2822 - c6bf - 4d9b - a2f6 - 24353a19479d",
                            ConcurrencyStamp = "ed3cabe8-400a-458b-b93f-fd2a1db877b4",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "5e8d9ce7-5855-4387-ad20-4661f3812f69",
                            ConcurrencyStamp = "d5097acf-307e-4766-8fff-df8bf4b0e82d",
                            Name = "Personal Trainer",
                            NormalizedName = "PERSONAL TRAINER"
                        },
                        new
                        {
                            Id = "4446da1c-6691-4045-9736-6cd4c5d8cf15",
                            ConcurrencyStamp = "f7284e01-1af2-4e5b-92ae-79187ab5d8d2",
                            Name = "Client",
                            NormalizedName = "CLIENT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "83200414-71f0-489a-858c-2987c08bb605",
                            Email = "Matsusanity@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "MATSUSANITY@GMAIL.COM",
                            NormalizedUserName = "MATSUSANITY@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ2aXds3INtVU+BgPsO/JvY6QX2QHPfHxwPdWH3RvVAo5alme/Lqxo/X3z3EreXU+Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "Matsusanity@gmail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                            RoleId = "556b2822 - c6bf - 4d9b - a2f6 - 24353a19479d"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Matsusanity.Models.Administrator", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Matsusanity.Models.Client", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("Matsusanity.Models.WorkoutPlan", "WorkoutPlan")
                        .WithMany()
                        .HasForeignKey("WorkoutPlanId");
                });

            modelBuilder.Entity("Matsusanity.Models.PersonalTrainer", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Matsusanity.Models.Workout", b =>
                {
                    b.HasOne("Matsusanity.Models.WorkoutPlan", "WorkoutPlan")
                        .WithMany()
                        .HasForeignKey("WorkoutPlanId");
                });

            modelBuilder.Entity("Matsusanity.Models.WorkoutPlan", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}