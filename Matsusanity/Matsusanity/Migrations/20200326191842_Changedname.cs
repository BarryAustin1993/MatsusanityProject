using Microsoft.EntityFrameworkCore.Migrations;

namespace Matsusanity.Migrations
{
    public partial class Changedname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CalendarClientWorkouts",
                table: "CalendarClientWorkouts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51208f1f-fdd7-4af9-8f5d-32a5a6dac8a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "899e3f20-d873-4d58-8baf-3d984665367b");

            migrationBuilder.RenameTable(
                name: "CalendarClientWorkouts",
                newName: "CalendarPlanWorkouts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalendarPlanWorkouts",
                table: "CalendarPlanWorkouts",
                columns: new[] { "WorkoutId", "WorkoutPlanId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "556b2822 - c6bf - 4d9b - a2f6 - 24353a19479d",
                column: "ConcurrencyStamp",
                value: "48ccabed-d9cc-4476-a2d4-b1c1b8f5d11f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f18e1621-6d2c-4073-acf0-a9f42309f1fb", "d028eaa8-1a49-4897-b414-cda81d2ab44a", "Personal Trainer", "PERSONAL TRAINER" },
                    { "bbebef0d-47fb-4db6-8fad-79149fc28cef", "df8bd14e-fb9c-43b4-8eb3-3277d97b6577", "Client", "CLIENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cc5f54ae-82bd-4acb-bdeb-657f1bbd2f73", "AQAAAAEAACcQAAAAEDxIaB8MqOnr+KUHxTbppNWTH80w3b6aNAZkENwfj5MBQFh0B54ofNPX+0d/INNmhQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CalendarPlanWorkouts",
                table: "CalendarPlanWorkouts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbebef0d-47fb-4db6-8fad-79149fc28cef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f18e1621-6d2c-4073-acf0-a9f42309f1fb");

            migrationBuilder.RenameTable(
                name: "CalendarPlanWorkouts",
                newName: "CalendarClientWorkouts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalendarClientWorkouts",
                table: "CalendarClientWorkouts",
                columns: new[] { "WorkoutId", "WorkoutPlanId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "556b2822 - c6bf - 4d9b - a2f6 - 24353a19479d",
                column: "ConcurrencyStamp",
                value: "abf82160-f641-4d3d-b381-e36d2ffbc646");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "51208f1f-fdd7-4af9-8f5d-32a5a6dac8a9", "477f0b06-924c-492e-8014-3bd541e69ec3", "Personal Trainer", "PERSONAL TRAINER" },
                    { "899e3f20-d873-4d58-8baf-3d984665367b", "1c7151fa-ace7-48cf-86bb-0d506154e6bf", "Client", "CLIENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8b717dcf-d8f4-4b2f-b2c3-f75ea4c43067", "AQAAAAEAACcQAAAAEO3Zk2nm2OONcovoOJq+7GSzLt3TX7ScTbZeFZMAj2vMpfgCy6KXX3XyZZV/aAIKAg==" });
        }
    }
}
