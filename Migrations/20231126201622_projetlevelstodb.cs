using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSProjectFollowUp.Migrations
{
    /// <inheritdoc />
    public partial class projetlevelstodb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectLevels",
                columns: table => new
                {
                    PLevel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    SectionId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "DateTime2(0)", nullable: true),
                    CreaterId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DateTime2(0)", nullable: true),
                    UpdaterId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectLevels", x => x.PLevel);
                    table.ForeignKey(
                        name: "FK_ProjectLevels_AspNetUsers_CreaterId",
                        column: x => x.CreaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectLevels_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectLevels_Companies_CompId",
                        column: x => x.CompId,
                        principalTable: "Companies",
                        principalColumn: "CompId");
                    table.ForeignKey(
                        name: "FK_ProjectLevels_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId");
                    table.ForeignKey(
                        name: "FK_ProjectLevels_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLevels_CompId",
                table: "ProjectLevels",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLevels_CreaterId",
                table: "ProjectLevels",
                column: "CreaterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLevels_DepartmentId",
                table: "ProjectLevels",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLevels_SectionId",
                table: "ProjectLevels",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLevels_UpdaterId",
                table: "ProjectLevels",
                column: "UpdaterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectLevels");
        }
    }
}
