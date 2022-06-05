using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayrollAPI.Migrations
{
    public partial class Addeducations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEducations_EmployeeDetails_EmployeeDetailEmployeeId",
                table: "EmployeeEducations");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeDetailEmployeeId",
                table: "EmployeeEducations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEducations_EmployeeDetails_EmployeeDetailEmployeeId",
                table: "EmployeeEducations",
                column: "EmployeeDetailEmployeeId",
                principalTable: "EmployeeDetails",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEducations_EmployeeDetails_EmployeeDetailEmployeeId",
                table: "EmployeeEducations");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeDetailEmployeeId",
                table: "EmployeeEducations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEducations_EmployeeDetails_EmployeeDetailEmployeeId",
                table: "EmployeeEducations",
                column: "EmployeeDetailEmployeeId",
                principalTable: "EmployeeDetails",
                principalColumn: "EmployeeId");
        }
    }
}
