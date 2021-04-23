using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinesweeperServer.Migrations
{
    public partial class AddedGameRecordEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComplexityLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Complexity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplexityLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsWin = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlayerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ComplexityLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameRecords_AspNetUsers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameRecords_ComplexityLevels_ComplexityLevelId",
                        column: x => x.ComplexityLevelId,
                        principalTable: "ComplexityLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ComplexityLevels",
                columns: new[] { "Id", "Complexity" },
                values: new object[] { -1, "Beginner" });

            migrationBuilder.InsertData(
                table: "ComplexityLevels",
                columns: new[] { "Id", "Complexity" },
                values: new object[] { -2, "Intermediate" });

            migrationBuilder.InsertData(
                table: "ComplexityLevels",
                columns: new[] { "Id", "Complexity" },
                values: new object[] { -3, "Advanced" });

            migrationBuilder.CreateIndex(
                name: "IX_GameRecords_ComplexityLevelId",
                table: "GameRecords",
                column: "ComplexityLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRecords_PlayerId",
                table: "GameRecords",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameRecords");

            migrationBuilder.DropTable(
                name: "ComplexityLevels");
        }
    }
}
