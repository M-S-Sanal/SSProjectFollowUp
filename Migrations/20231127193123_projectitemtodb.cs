using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSProjectFollowUp.Migrations
{
    /// <inheritdoc />
    public partial class projectitemtodb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectItems",
                columns: table => new
                {
                    PSId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: true),
                    DueDate = table.Column<DateTime>(type: "Date", nullable: true),
                    InCharge = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreaterId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdaterId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProPlevel = table.Column<int>(type: "int", nullable: true),
                    PId = table.Column<int>(type: "int", nullable: true),
                    PLevel = table.Column<int>(type: "int", nullable: false),
                    PSSId = table.Column<int>(type: "int", nullable: true),
                    OrderColumn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectItems", x => x.PSId);
                    table.ForeignKey(
                        name: "FK_ProjectItems_AspNetUsers_CreaterId",
                        column: x => x.CreaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectItems_AspNetUsers_InCharge",
                        column: x => x.InCharge,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectItems_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectItems_Companies_CompId",
                        column: x => x.CompId,
                        principalTable: "Companies",
                        principalColumn: "CompId");
                    table.ForeignKey(
                        name: "FK_ProjectItems_ProjectLevels_PLevel",
                        column: x => x.PLevel,
                        principalTable: "ProjectLevels",
                        principalColumn: "PLevel",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectItems_Projects_PId",
                        column: x => x.PId,
                        principalTable: "Projects",
                        principalColumn: "PId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItems_CompId",
                table: "ProjectItems",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItems_CreaterId",
                table: "ProjectItems",
                column: "CreaterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItems_InCharge",
                table: "ProjectItems",
                column: "InCharge");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItems_PId",
                table: "ProjectItems",
                column: "PId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItems_PLevel",
                table: "ProjectItems",
                column: "PLevel");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItems_UpdaterId",
                table: "ProjectItems",
                column: "UpdaterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectItems");
        }
    }
}
