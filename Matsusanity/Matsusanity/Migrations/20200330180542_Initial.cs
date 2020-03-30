using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Matsusanity.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CalendarPlanWorkouts",
                columns: table => new
                {
                    WorkoutPlanId = table.Column<int>(nullable: false),
                    WorkoutId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: true),
                    AllDay = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarPlanWorkouts", x => new { x.WorkoutId, x.WorkoutPlanId });
                });

            migrationBuilder.CreateTable(
                name: "PersonalTrainersClients",
                columns: table => new
                {
                    PersonalTrainerId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalTrainersClients", x => new { x.PersonalTrainerId, x.ClientId });
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrator_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalTrainers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    InPersonSessions = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalTrainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalTrainers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutPlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutPlans_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    WorkoutPlanId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Client_WorkoutPlans_WorkoutPlanId",
                        column: x => x.WorkoutPlanId,
                        principalTable: "WorkoutPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutPlanId = table.Column<int>(nullable: true),
                    ExerciseOne = table.Column<string>(nullable: true),
                    RepsOne = table.Column<string>(nullable: true),
                    SetsOne = table.Column<string>(nullable: true),
                    WeightOne = table.Column<string>(nullable: true),
                    ExerciseTwo = table.Column<string>(nullable: true),
                    RepsTwo = table.Column<string>(nullable: true),
                    SetsTwo = table.Column<string>(nullable: true),
                    WeightTwo = table.Column<string>(nullable: true),
                    ExerciseThree = table.Column<string>(nullable: true),
                    RepsThree = table.Column<string>(nullable: true),
                    SetsThree = table.Column<string>(nullable: true),
                    WeightThree = table.Column<string>(nullable: true),
                    ExerciseFour = table.Column<string>(nullable: true),
                    RepsFour = table.Column<string>(nullable: true),
                    SetsFour = table.Column<string>(nullable: true),
                    WeightFour = table.Column<string>(nullable: true),
                    ExerciseFive = table.Column<string>(nullable: true),
                    RepsFive = table.Column<string>(nullable: true),
                    SetsFive = table.Column<string>(nullable: true),
                    WeightFive = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workouts_WorkoutPlans_WorkoutPlanId",
                        column: x => x.WorkoutPlanId,
                        principalTable: "WorkoutPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "556b2822 - c6bf - 4d9b - a2f6 - 24353a19479d", "ed3cabe8-400a-458b-b93f-fd2a1db877b4", "Administrator", "ADMINISTRATOR" },
                    { "5e8d9ce7-5855-4387-ad20-4661f3812f69", "d5097acf-307e-4766-8fff-df8bf4b0e82d", "Personal Trainer", "PERSONAL TRAINER" },
                    { "4446da1c-6691-4045-9736-6cd4c5d8cf15", "f7284e01-1af2-4e5b-92ae-79187ab5d8d2", "Client", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", 0, "83200414-71f0-489a-858c-2987c08bb605", "Matsusanity@gmail.com", true, false, null, "MATSUSANITY@GMAIL.COM", "MATSUSANITY@GMAIL.COM", "AQAAAAEAACcQAAAAEJ2aXds3INtVU+BgPsO/JvY6QX2QHPfHxwPdWH3RvVAo5alme/Lqxo/X3z3EreXU+Q==", null, false, "", false, "Matsusanity@gmail.com" });

            migrationBuilder.InsertData(
                table: "CalendarPlanWorkouts",
                columns: new[] { "WorkoutId", "WorkoutPlanId", "AllDay", "Description", "End", "Start", "Title" },
                values: new object[,]
                {
                    { 1, 1, true, "no weights, just body", null, new DateTime(2020, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Body" },
                    { 2, 1, true, "Lower Body with equipment", null, new DateTime(2020, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Upper" },
                    { 3, 1, true, "Upper body with equipment", null, new DateTime(2020, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lower" },
                    { 4, 2, true, "no weights, just body", null, new DateTime(2020, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Body" },
                    { 5, 2, true, "Lower Body with equipment", null, new DateTime(2020, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Upper" },
                    { 6, 2, true, "Upper body with equipment", null, new DateTime(2020, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lower" },
                    { 7, 3, true, "no weights, just body", null, new DateTime(2020, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Body" },
                    { 8, 3, true, "Lower Body with equipment", null, new DateTime(2020, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Upper" },
                    { 9, 3, true, "Upper body with equipment", null, new DateTime(2020, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lower" }
                });

            migrationBuilder.InsertData(
                table: "Administrator",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 1, "Yuki", "Matsushima", "a18be9c0-aa65-4af8-bd17-00bd9344e575" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", "556b2822 - c6bf - 4d9b - a2f6 - 24353a19479d" });

            migrationBuilder.InsertData(
                table: "WorkoutPlans",
                columns: new[] { "Id", "Description", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "This plan is designed for you to gain muscle", "Gain Muscle", "a18be9c0-aa65-4af8-bd17-00bd9344e575" },
                    { 2, "This plan is designed for you to lose weight", "Lose Weight", "a18be9c0-aa65-4af8-bd17-00bd9344e575" },
                    { 3, "This plan is designed for you to get fit", "Get Fit", "a18be9c0-aa65-4af8-bd17-00bd9344e575" }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "ExerciseFive", "ExerciseFour", "ExerciseOne", "ExerciseThree", "ExerciseTwo", "RepsFive", "RepsFour", "RepsOne", "RepsThree", "RepsTwo", "SetsFive", "SetsFour", "SetsOne", "SetsThree", "SetsTwo", "WeightFive", "WeightFour", "WeightOne", "WeightThree", "WeightTwo", "WorkoutPlanId" },
                values: new object[,]
                {
                    { 1, "Jumping Jacks", "Body Squats", "Pull-Ups", "Mountains Climbers", "Push-Ups", "10", "10", "10", "10", "10", "3", "3", "3", "3", "3", "10", "10", "10", "10", "10", 1 },
                    { 2, "Shoulder Shrugs", "Skull Crushers", "Bench Press", "OverHead Press", "Bicep Curls", "10", "10", "10", "10", "10", "3", "3", "3", "3", "3", "10", "10", "10", "10", "10", 1 },
                    { 3, "Box Jumps", "Calf Raises", "Squats", "Leg Curl", "Leg Press", "10", "10", "10", "10", "10", "3", "3", "3", "3", "3", "10", "10", "10", "10", "10", 1 },
                    { 4, "Jumping Jacks", "Body Squats", "Pull-Ups", "Mountains Climbers", "Push-Ups", "10", "10", "10", "10", "10", "3", "3", "3", "3", "3", "10", "10", "10", "10", "10", 2 },
                    { 5, "Shoulder Shrugs", "Skull Crushers", "Bench Press", "OverHead Press", "Bicep Curls", "10", "10", "10", "10", "10", "3", "3", "3", "3", "3", "10", "10", "10", "10", "10", 2 },
                    { 6, "Box Jumps", "Calf Raises", "Squats", "Leg Curl", "Leg Press", "10", "10", "10", "10", "10", "3", "3", "3", "3", "3", "10", "10", "10", "10", "10", 2 },
                    { 7, "Jumping Jacks", "Body Squats", "Pull-Ups", "Mountains Climbers", "Push-Ups", "10", "10", "10", "10", "10", "3", "3", "3", "3", "3", "10", "10", "10", "10", "10", 3 },
                    { 8, "Shoulder Shrugs", "Skull Crushers", "Bench Press", "OverHead Press", "Bicep Curls", "10", "10", "10", "10", "10", "3", "3", "3", "3", "3", "10", "10", "10", "10", "10", 3 },
                    { 9, "Box Jumps", "Calf Raises", "Squats", "Leg Curl", "Leg Press", "10", "10", "10", "10", "10", "3", "3", "3", "3", "3", "10", "10", "10", "10", "10", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_UserId",
                table: "Administrator",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Client_UserId",
                table: "Client",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_WorkoutPlanId",
                table: "Client",
                column: "WorkoutPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalTrainers_UserId",
                table: "PersonalTrainers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPlans_UserId",
                table: "WorkoutPlans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_WorkoutPlanId",
                table: "Workouts",
                column: "WorkoutPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CalendarPlanWorkouts");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "PersonalTrainers");

            migrationBuilder.DropTable(
                name: "PersonalTrainersClients");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "WorkoutPlans");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
