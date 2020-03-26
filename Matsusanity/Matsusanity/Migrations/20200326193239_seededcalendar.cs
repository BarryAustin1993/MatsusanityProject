using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Matsusanity.Migrations
{
    public partial class seededcalendar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbebef0d-47fb-4db6-8fad-79149fc28cef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f18e1621-6d2c-4073-acf0-a9f42309f1fb");

            migrationBuilder.DeleteData(
                table: "CalendarPlanWorkouts",
                keyColumns: new[] { "WorkoutId", "WorkoutPlanId" },
                keyValues: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "556b2822 - c6bf - 4d9b - a2f6 - 24353a19479d",
                column: "ConcurrencyStamp",
                value: "0f09cc7f-310b-4b3a-9521-184c5a58717f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0072deb7-a8bd-45ee-b8b0-a41d9934d497", "c70c09c4-3506-4d96-9cfc-28e2168cad06", "Personal Trainer", "PERSONAL TRAINER" },
                    { "84ec30ce-3193-44f5-befa-44bce7081174", "b56c75b0-fba1-4cc7-8183-83f94886120d", "Client", "CLIENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c8cb71fc-e412-42f0-96bb-1e4c01856bf4", "AQAAAAEAACcQAAAAEIRMqgDOy1tTmK1ZLVGZCh5ivYEv4Gk7VYQHGxcp84nvK3fQ+vQmIOfFh3K3qTJaCQ==" });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0072deb7-a8bd-45ee-b8b0-a41d9934d497");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84ec30ce-3193-44f5-befa-44bce7081174");

            migrationBuilder.DeleteData(
                table: "CalendarPlanWorkouts",
                keyColumns: new[] { "WorkoutId", "WorkoutPlanId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CalendarPlanWorkouts",
                keyColumns: new[] { "WorkoutId", "WorkoutPlanId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CalendarPlanWorkouts",
                keyColumns: new[] { "WorkoutId", "WorkoutPlanId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "CalendarPlanWorkouts",
                keyColumns: new[] { "WorkoutId", "WorkoutPlanId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "CalendarPlanWorkouts",
                keyColumns: new[] { "WorkoutId", "WorkoutPlanId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "CalendarPlanWorkouts",
                keyColumns: new[] { "WorkoutId", "WorkoutPlanId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "CalendarPlanWorkouts",
                keyColumns: new[] { "WorkoutId", "WorkoutPlanId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "CalendarPlanWorkouts",
                keyColumns: new[] { "WorkoutId", "WorkoutPlanId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "CalendarPlanWorkouts",
                keyColumns: new[] { "WorkoutId", "WorkoutPlanId" },
                keyValues: new object[] { 9, 3 });

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

            migrationBuilder.InsertData(
                table: "CalendarPlanWorkouts",
                columns: new[] { "WorkoutId", "WorkoutPlanId", "AllDay", "Description", "End", "Start", "Title" },
                values: new object[] { 0, 0, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });
        }
    }
}
