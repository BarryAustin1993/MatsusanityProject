using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Matsusanity.Data.Migrations
{
    public partial class AddedTwoModelsForClientFunctionalityAttemptFive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "052019be-6b6c-4a36-a28e-2ab2ef26c44a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c44a882-eb08-43b9-ba4b-b85749e5d2dc");

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                });

            migrationBuilder.CreateTable(
                name: "CalendarClientWorkouts",
                columns: table => new
                {
                    ClientId = table.Column<string>(nullable: false),
                    WorkoutId = table.Column<string>(nullable: false),
                    ClientId1 = table.Column<int>(nullable: true),
                    WorkoutId1 = table.Column<int>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarClientWorkouts", x => new { x.WorkoutId, x.ClientId });
                    table.ForeignKey(
                        name: "FK_CalendarClientWorkouts_Client_ClientId1",
                        column: x => x.ClientId1,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CalendarClientWorkouts_Workouts_WorkoutId1",
                        column: x => x.WorkoutId1,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "556b2822 - c6bf - 4d9b - a2f6 - 24353a19479d",
                column: "ConcurrencyStamp",
                value: "6c08af47-4f86-4597-9fcc-dfd95a1321e4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bf747327-e6b0-4475-b82e-34848034a61a", "f538b197-19d1-4361-bbec-3f3616ceba23", "Personal Trainer", "PERSONAL TRAINER" },
                    { "d24c7058-9a6d-4c61-85b0-d781fb181fcd", "533c52e2-292d-4352-b2c5-b7e11fbcacd3", "Client", "CLIENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4681b3a2-fa86-49d4-9aa2-01a5c02ccb9f", "AQAAAAEAACcQAAAAEMxtAuld0U8H0rMV7NjxEHsKTICe/m0ITGvxaV3SASnJyhjQDABlsWxRCA6ZYYdF4Q==" });

            migrationBuilder.CreateIndex(
                name: "IX_CalendarClientWorkouts_ClientId1",
                table: "CalendarClientWorkouts",
                column: "ClientId1");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarClientWorkouts_WorkoutId1",
                table: "CalendarClientWorkouts",
                column: "WorkoutId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalendarClientWorkouts");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf747327-e6b0-4475-b82e-34848034a61a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d24c7058-9a6d-4c61-85b0-d781fb181fcd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "556b2822 - c6bf - 4d9b - a2f6 - 24353a19479d",
                column: "ConcurrencyStamp",
                value: "4e8c7e9b-6d2d-42fc-b434-8c6b0b867e8c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8c44a882-eb08-43b9-ba4b-b85749e5d2dc", "234ed191-aa7b-4601-a9c6-d11604eac742", "Personal Trainer", "PERSONAL TRAINER" },
                    { "052019be-6b6c-4a36-a28e-2ab2ef26c44a", "81f29eab-467a-4954-95db-665a82d664c4", "Client", "CLIENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2965d764-3480-42b6-8d6b-308e8ec84a01", "AQAAAAEAACcQAAAAEBCkKkBPa3TGzb/iu6g8MEcEXXdn6N/tlHWvM0/Ydl2HETgs0mJ5WBD2YChAL8TXUw==" });
        }
    }
}
