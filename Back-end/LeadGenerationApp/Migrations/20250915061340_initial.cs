using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeadGenerationApp.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Budget = table.Column<double>(type: "float", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Area = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Dashboard",
                columns: table => new
                {
                    DashboardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalLeads = table.Column<int>(type: "int", nullable: false),
                    TotalCompleted = table.Column<int>(type: "int", nullable: false),
                    PendingLeft = table.Column<int>(type: "int", nullable: false),
                    TodaysAppointment = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dashboard", x => x.DashboardId);
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManagerName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.ManagerId);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    PermissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Read = table.Column<bool>(type: "bit", nullable: false),
                    Write = table.Column<bool>(type: "bit", nullable: false),
                    Update = table.Column<bool>(type: "bit", nullable: false),
                    Insert = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.PermissionID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RollID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RollName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermissionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RollID);
                    table.ForeignKey(
                        name: "FK_Roles_Permission_PermissionID",
                        column: x => x.PermissionID,
                        principalTable: "Permission",
                        principalColumn: "PermissionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RollID = table.Column<int>(type: "int", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RollID",
                        column: x => x.RollID,
                        principalTable: "Roles",
                        principalColumn: "RollID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lead",
                columns: table => new
                {
                    LeadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lead", x => x.LeadId);
                    table.ForeignKey(
                        name: "FK_Lead_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Team_Manager_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Manager",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Team_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeadAssign",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LeadAssignId = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Permition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeadAssignId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadAssign", x => x.LeadAssignId);
                    table.ForeignKey(
                        name: "FK_LeadAssign_LeadAssign_LeadAssignId1",
                        column: x => x.LeadAssignId1,
                        principalTable: "LeadAssign",
                        principalColumn: "LeadAssignId");
                    table.ForeignKey(
                        name: "FK_LeadAssign_Lead_LeadAssignId",
                        column: x => x.LeadAssignId,
                        principalTable: "Lead",
                        principalColumn: "LeadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadAssign_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lead_UserId",
                table: "Lead",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadAssign_LeadAssignId1",
                table: "LeadAssign",
                column: "LeadAssignId1");

            migrationBuilder.CreateIndex(
                name: "IX_LeadAssign_UserId",
                table: "LeadAssign",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_PermissionID",
                table: "Roles",
                column: "PermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_Team_ManagerId",
                table: "Team",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_UserId",
                table: "Team",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RollID",
                table: "Users",
                column: "RollID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Dashboard");

            migrationBuilder.DropTable(
                name: "LeadAssign");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Lead");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Permission");
        }
    }
}
