using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSProjectFollowUp.Migrations
{
    /// <inheritdoc />
    public partial class companycrossupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCrosses_Departments_DepartmentId",
                table: "CompanyCrosses");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCrosses_Sections_SectionId",
                table: "CompanyCrosses");

            migrationBuilder.AlterColumn<int>(
                name: "SectionId",
                table: "CompanyCrosses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "CompanyCrosses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCrosses_Departments_DepartmentId",
                table: "CompanyCrosses",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCrosses_Sections_SectionId",
                table: "CompanyCrosses",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "SectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCrosses_Departments_DepartmentId",
                table: "CompanyCrosses");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCrosses_Sections_SectionId",
                table: "CompanyCrosses");

            migrationBuilder.AlterColumn<int>(
                name: "SectionId",
                table: "CompanyCrosses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "CompanyCrosses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCrosses_Departments_DepartmentId",
                table: "CompanyCrosses",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCrosses_Sections_SectionId",
                table: "CompanyCrosses",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "SectionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
