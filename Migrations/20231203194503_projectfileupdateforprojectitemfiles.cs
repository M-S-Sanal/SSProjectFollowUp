using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSProjectFollowUp.Migrations
{
    /// <inheritdoc />
    public partial class projectfileupdateforprojectitemfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PSId",
                table: "ProjectFiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFiles_PSId",
                table: "ProjectFiles",
                column: "PSId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectFiles_ProjectItems_PSId",
                table: "ProjectFiles",
                column: "PSId",
                principalTable: "ProjectItems",
                principalColumn: "PSId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectFiles_ProjectItems_PSId",
                table: "ProjectFiles");

            migrationBuilder.DropIndex(
                name: "IX_ProjectFiles_PSId",
                table: "ProjectFiles");

            migrationBuilder.DropColumn(
                name: "PSId",
                table: "ProjectFiles");
        }
    }
}
