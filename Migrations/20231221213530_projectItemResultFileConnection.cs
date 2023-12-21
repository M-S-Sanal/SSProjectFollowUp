using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSProjectFollowUp.Migrations
{
    /// <inheritdoc />
    public partial class projectItemResultFileConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PSRId",
                table: "ProjectFiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFiles_PSRId",
                table: "ProjectFiles",
                column: "PSRId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectFiles_ProjectItemResults_PSRId",
                table: "ProjectFiles",
                column: "PSRId",
                principalTable: "ProjectItemResults",
                principalColumn: "PSRId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectFiles_ProjectItemResults_PSRId",
                table: "ProjectFiles");

            migrationBuilder.DropIndex(
                name: "IX_ProjectFiles_PSRId",
                table: "ProjectFiles");

            migrationBuilder.DropColumn(
                name: "PSRId",
                table: "ProjectFiles");
        }
    }
}
