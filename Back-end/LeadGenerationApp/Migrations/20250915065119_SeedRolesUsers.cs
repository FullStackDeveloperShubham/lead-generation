using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeadGenerationApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedRolesUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RollID", "PermissionID", "RollName" },
                values: new object[,]
                {
                    { 1, 1, "Admin" },
                    { 2, 2, "Manager" },
                    { 3, 3, "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "RollID", "UserName", "UserPassword" },
                values: new object[,]
                {
                    { 1, 1, "AliceAdmin", "admin123" },
                    { 2, 2, "BobManager", "manager123" },
                    { 3, 3, "CharlieTeam", "user123" },
                    { 4, 3, "DianaTeam", "user123" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RollID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RollID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RollID",
                keyValue: 3);
        }
    }
}
