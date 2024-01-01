using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSProjectFollowUp.Migrations
{
    /// <inheritdoc />
    public partial class fileLeveltoDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PFLevel",
                table: "ProjectFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FileLevels",
                columns: table => new
                {
                    PFLevel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FValue = table.Column<int>(type: "int", nullable: false),
                    CompId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    SectionId = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DateTime2(0)", nullable: true),
                    UpdaterId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileLevels", x => x.PFLevel);
                    table.ForeignKey(
                        name: "FK_FileLevels_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FileLevels_Companies_CompId",
                        column: x => x.CompId,
                        principalTable: "Companies",
                        principalColumn: "CompId");
                    table.ForeignKey(
                        name: "FK_FileLevels_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId");
                    table.ForeignKey(
                        name: "FK_FileLevels_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFiles_PFLevel",
                table: "ProjectFiles",
                column: "PFLevel");

            migrationBuilder.CreateIndex(
                name: "IX_FileLevels_CompId",
                table: "FileLevels",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_FileLevels_DepartmentId",
                table: "FileLevels",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FileLevels_SectionId",
                table: "FileLevels",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FileLevels_UpdaterId",
                table: "FileLevels",
                column: "UpdaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectFiles_FileLevels_PFLevel",
                table: "ProjectFiles",
                column: "PFLevel",
                principalTable: "FileLevels",
                principalColumn: "PFLevel",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectFiles_FileLevels_PFLevel",
                table: "ProjectFiles");

            migrationBuilder.DropTable(
                name: "FileLevels");

            migrationBuilder.DropIndex(
                name: "IX_ProjectFiles_PFLevel",
                table: "ProjectFiles");

            migrationBuilder.DropColumn(
                name: "PFLevel",
                table: "ProjectFiles");
        }
    }
}
