using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeadGenerationApp.Migrations
{
    /// <inheritdoc />
    public partial class seedallusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "TeamId", "ManagerId", "TeamName", "UserId" },
                values: new object[,]
                {
                    { 1, 2, "Development", 3 },
                    { 2, 2, "Marketing", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Team",
                keyColumn: "TeamId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Team",
                keyColumn: "TeamId",
                keyValue: 2);
        }
    }
}
