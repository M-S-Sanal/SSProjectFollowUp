using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSProjectFollowUp.Migrations
{
    /// <inheritdoc />
    public partial class projectItemResultsToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectItemResults",
                columns: table => new
                {
                    PSRId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IncharCharge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PSRResult = table.Column<int>(type: "int", nullable: false),
                    PSRComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreaterId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PSId = table.Column<int>(type: "int", nullable: true),
                    PLevel = table.Column<int>(type: "int", nullable: false),
                    CompId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectItemResults", x => x.PSRId);
                    table.ForeignKey(
                        name: "FK_ProjectItemResults_AspNetUsers_CreaterId",
                        column: x => x.CreaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectItemResults_Companies_CompId",
                        column: x => x.CompId,
                        principalTable: "Companies",
                        principalColumn: "CompId");
                    table.ForeignKey(
                        name: "FK_ProjectItemResults_ProjectItems_PSId",
                        column: x => x.PSId,
                        principalTable: "ProjectItems",
                        principalColumn: "PSId");
                    table.ForeignKey(
                        name: "FK_ProjectItemResults_ProjectLevels_PLevel",
                        column: x => x.PLevel,
                        principalTable: "ProjectLevels",
                        principalColumn: "PLevel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItemResults_CompId",
                table: "ProjectItemResults",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItemResults_CreaterId",
                table: "ProjectItemResults",
                column: "CreaterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItemResults_PLevel",
                table: "ProjectItemResults",
                column: "PLevel");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItemResults_PSId",
                table: "ProjectItemResults",
                column: "PSId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectItemResults");
        }
    }
}
