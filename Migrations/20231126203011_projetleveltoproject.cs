using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSProjectFollowUp.Migrations
{
    /// <inheritdoc />
    public partial class projetleveltoproject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PLevel",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PLevel",
                table: "Projects",
                column: "PLevel");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectLevels_PLevel",
                table: "Projects",
                column: "PLevel",
                principalTable: "ProjectLevels",
                principalColumn: "PLevel",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectLevels_PLevel",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_PLevel",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "PLevel",
                table: "Projects");
        }
    }
}
