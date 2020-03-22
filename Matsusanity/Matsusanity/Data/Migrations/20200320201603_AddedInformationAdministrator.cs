using Microsoft.EntityFrameworkCore.Migrations;

namespace Matsusanity.Data.Migrations
{
    public partial class AddedInformationAdministrator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66d6a807-a737-4b1f-98dc-1f64560d2224");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5284ad2-22b0-4336-a485-139301f0e8db");

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
                name: "Client",
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
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonalTrainer",
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
                    table.PrimaryKey("PK_PersonalTrainer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalTrainer_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Administrator",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 1, "Yuki", "Matsushima", "a18be9c0-aa65-4af8-bd17-00bd9344e575" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_UserId",
                table: "Administrator",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_UserId",
                table: "Client",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalTrainer_UserId",
                table: "PersonalTrainer",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "PersonalTrainer");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b9bd9304-162d-44e3-a166-b01f1c6260de", "AQAAAAEAACcQAAAAEMXM1mkyab5ainxTteprKz3I6QO09QJd8UcQv7b+8bQ8n8JqGOAE5Lj07+2Fq0BTkQ==" });
        }
    }
}
