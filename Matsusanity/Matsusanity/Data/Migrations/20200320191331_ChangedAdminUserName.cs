using Microsoft.EntityFrameworkCore.Migrations;

namespace Matsusanity.Data.Migrations
{
    public partial class ChangedAdminUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6480fa8f-b5f3-4206-92c7-3468d09921d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74e66144-eddb-413e-bb62-5c55bdc639ae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "556b2822 - c6bf - 4d9b - a2f6 - 24353a19479d",
                column: "ConcurrencyStamp",
                value: "f4e7f2d4-6dea-47ea-a11d-6e0ffd5dff6f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b5284ad2-22b0-4336-a485-139301f0e8db", "07b55834-698a-41a5-9d6c-5b2ebd002e8c", "Personal Trainer", "PERSONAL TRAINER" },
                    { "66d6a807-a737-4b1f-98dc-1f64560d2224", "1c02272f-3eec-4ce4-9348-64c73a61affd", "Client", "CLIENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "b9bd9304-162d-44e3-a166-b01f1c6260de", "MATSUSANITY@GMAIL.COM", "AQAAAAEAACcQAAAAEMXM1mkyab5ainxTteprKz3I6QO09QJd8UcQv7b+8bQ8n8JqGOAE5Lj07+2Fq0BTkQ==", "Matsusanity@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66d6a807-a737-4b1f-98dc-1f64560d2224");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5284ad2-22b0-4336-a485-139301f0e8db");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "556b2822 - c6bf - 4d9b - a2f6 - 24353a19479d",
                column: "ConcurrencyStamp",
                value: "5290cfb4-1c3e-4e19-a921-9dc999f59f88");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "74e66144-eddb-413e-bb62-5c55bdc639ae", "dd7d5495-a8cb-4fff-8b2c-b2da19c07666", "Personal Trainer", "PERSONAL TRAINER" },
                    { "6480fa8f-b5f3-4206-92c7-3468d09921d7", "11c90d97-200c-4a6f-b333-cb05f7c4cef4", "Client", "CLIENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "18e93d04-f70f-45b9-8d40-2913690da36c", "MATSU", "AQAAAAEAACcQAAAAEFfpFUOtAPf9i0WeizqdjdY54BeIzB6i0CBv6Nz9gk9VJS+pkvdzx11FJFGwYpKjow==", "Matsu" });
        }
    }
}
