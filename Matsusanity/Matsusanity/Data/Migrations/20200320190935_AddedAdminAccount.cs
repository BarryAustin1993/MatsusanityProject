using Microsoft.EntityFrameworkCore.Migrations;

namespace Matsusanity.Data.Migrations
{
    public partial class AddedAdminAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95abb6f9-6ac3-4666-b8f3-1b6ed1f25126");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb2e6f9e-0a55-4cc8-a4cc-e89430ee8a2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4a9fa95-a796-487c-97f7-e7ebc920f655");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "556b2822 - c6bf - 4d9b - a2f6 - 24353a19479d", "5290cfb4-1c3e-4e19-a921-9dc999f59f88", "Administrator", "ADMINISTRATOR" },
                    { "74e66144-eddb-413e-bb62-5c55bdc639ae", "dd7d5495-a8cb-4fff-8b2c-b2da19c07666", "Personal Trainer", "PERSONAL TRAINER" },
                    { "6480fa8f-b5f3-4206-92c7-3468d09921d7", "11c90d97-200c-4a6f-b333-cb05f7c4cef4", "Client", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", 0, "18e93d04-f70f-45b9-8d40-2913690da36c", "Matsusanity@gmail.com", true, false, null, "MATSUSANITY@GMAIL.COM", "MATSU", "AQAAAAEAACcQAAAAEFfpFUOtAPf9i0WeizqdjdY54BeIzB6i0CBv6Nz9gk9VJS+pkvdzx11FJFGwYpKjow==", null, false, "", false, "Matsu" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", "556b2822 - c6bf - 4d9b - a2f6 - 24353a19479d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6480fa8f-b5f3-4206-92c7-3468d09921d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74e66144-eddb-413e-bb62-5c55bdc639ae");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", "556b2822 - c6bf - 4d9b - a2f6 - 24353a19479d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "556b2822 - c6bf - 4d9b - a2f6 - 24353a19479d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4a9fa95-a796-487c-97f7-e7ebc920f655", "2a0ba0f0-cc60-40d5-89a8-ff58841b37b2", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "95abb6f9-6ac3-4666-b8f3-1b6ed1f25126", "1245384d-8d0f-4ef4-b6ce-500f44e4a843", "Personal Trainer", "PERSONAL TRAINER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bb2e6f9e-0a55-4cc8-a4cc-e89430ee8a2b", "0c6e6252-5c5b-4064-9809-7442088be27a", "Client", "CLIENT" });
        }
    }
}
