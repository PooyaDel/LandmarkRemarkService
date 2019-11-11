using Microsoft.EntityFrameworkCore.Migrations;

namespace LandmarkRemarkService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserContextInfo",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContextInfo", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "MapLandmark",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(nullable: false),
                    Lat = table.Column<double>(nullable: false),
                    Lng = table.Column<double>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapLandmark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MapLandmark_UserContextInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UserContextInfo",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserContextInfo",
                columns: new[] { "UserId", "Email", "Name", "Password" },
                values: new object[] { "guest1", "testUser1@testuser1.com", "Test User1", "1" });

            migrationBuilder.InsertData(
                table: "UserContextInfo",
                columns: new[] { "UserId", "Email", "Name", "Password" },
                values: new object[] { "guest2", "testUser2@testuser2.com", "Test User2", "2" });

            migrationBuilder.CreateIndex(
                name: "IX_MapLandmark_UserId",
                table: "MapLandmark",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MapLandmark");

            migrationBuilder.DropTable(
                name: "UserContextInfo");
        }
    }
}
