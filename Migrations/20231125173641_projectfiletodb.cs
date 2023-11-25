using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSProjectFollowUp.Migrations
{
    /// <inheritdoc />
    public partial class projectfiletodb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectFiles",
                columns: table => new
                {
                    PFId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FNo = table.Column<int>(type: "int", nullable: false),
                    FExtention = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PId = table.Column<int>(type: "int", nullable: true),
                    CompId = table.Column<int>(type: "int", nullable: true),
                    CreaterId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFiles", x => x.PFId);
                    table.ForeignKey(
                        name: "FK_ProjectFiles_AspNetUsers_CreaterId",
                        column: x => x.CreaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectFiles_Companies_CompId",
                        column: x => x.CompId,
                        principalTable: "Companies",
                        principalColumn: "CompId");
                    table.ForeignKey(
                        name: "FK_ProjectFiles_Projects_PId",
                        column: x => x.PId,
                        principalTable: "Projects",
                        principalColumn: "PId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFiles_CompId",
                table: "ProjectFiles",
                column: "CompId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFiles_CreaterId",
                table: "ProjectFiles",
                column: "CreaterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFiles_PId",
                table: "ProjectFiles",
                column: "PId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectFiles");
        }
    }
}
