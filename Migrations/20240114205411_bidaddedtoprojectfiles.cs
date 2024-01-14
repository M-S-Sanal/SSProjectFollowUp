using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSProjectFollowUp.Migrations
{
    /// <inheritdoc />
    public partial class bidaddedtoprojectfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BId",
                table: "ProjectFiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFiles_BId",
                table: "ProjectFiles",
                column: "BId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectFiles_BusinessCases_BId",
                table: "ProjectFiles",
                column: "BId",
                principalTable: "BusinessCases",
                principalColumn: "BId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectFiles_BusinessCases_BId",
                table: "ProjectFiles");

            migrationBuilder.DropIndex(
                name: "IX_ProjectFiles_BId",
                table: "ProjectFiles");

            migrationBuilder.DropColumn(
                name: "BId",
                table: "ProjectFiles");
        }
    }
}
