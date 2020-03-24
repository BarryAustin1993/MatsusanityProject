using Microsoft.EntityFrameworkCore.Migrations;

namespace Matsusanity.Data.Migrations
{
    public partial class AddedTwoModelsForClientFunctionality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02977383-b170-40f1-b9cc-404be1beb0fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79a67361-b66d-4362-94fb-4ebf1f7ea7bb");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "052019be-6b6c-4a36-a28e-2ab2ef26c44a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c44a882-eb08-43b9-ba4b-b85749e5d2dc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "556b2822 - c6bf - 4d9b - a2f6 - 24353a19479d",
                column: "ConcurrencyStamp",
                value: "b1fcbe95-9868-4e7c-a787-d0f0f07d54a6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "79a67361-b66d-4362-94fb-4ebf1f7ea7bb", "8dc74f51-1684-41fa-a8ee-da6fd9d462aa", "Personal Trainer", "PERSONAL TRAINER" },
                    { "02977383-b170-40f1-b9cc-404be1beb0fe", "b3611b26-966f-4be6-ab2c-8f6adccc06f3", "Client", "CLIENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "91cc6eba-0f56-47d4-afe6-51a449da6884", "AQAAAAEAACcQAAAAENsqz+o7g+1Yofz7bQaSmZsIRfhEz9rBiI3MsAUILKRY2FG81DBIpl0l3gjlRXLIbA==" });
        }
    }
}
