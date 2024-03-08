using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSProjectFollowUp.Migrations
{
    /// <inheritdoc />
    public partial class projectTimeLineToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectTimeLines",
                columns: table => new
                {
                    PTId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PId = table.Column<int>(type: "int", nullable: true),
                    PLevel = table.Column<int>(type: "int", nullable: true),
                    ForecastDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppliedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    StatusUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTimeLines", x => x.PTId);
                    table.ForeignKey(
                        name: "FK_ProjectTimeLines_AspNetUsers_StatusUserId",
                        column: x => x.StatusUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectTimeLines_ProjectLevels_PLevel",
                        column: x => x.PLevel,
                        principalTable: "ProjectLevels",
                        principalColumn: "PLevel");
                    table.ForeignKey(
                        name: "FK_ProjectTimeLines_ProjectLevels_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ProjectLevels",
                        principalColumn: "PLevel");
                    table.ForeignKey(
                        name: "FK_ProjectTimeLines_Projects_PId",
                        column: x => x.PId,
                        principalTable: "Projects",
                        principalColumn: "PId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTimeLines_PId",
                table: "ProjectTimeLines",
                column: "PId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTimeLines_PLevel",
                table: "ProjectTimeLines",
                column: "PLevel");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTimeLines_StatusId",
                table: "ProjectTimeLines",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTimeLines_StatusUserId",
                table: "ProjectTimeLines",
                column: "StatusUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectTimeLines");
        }
    }
}
