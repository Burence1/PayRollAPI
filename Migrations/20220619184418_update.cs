using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayrollAPI.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEducations_EmployeeDetails_EmployeeDetailEmployeeId",
                table: "EmployeeEducations");

            migrationBuilder.RenameColumn(
                name: "EmployeeDetailEmployeeId",
                table: "EmployeeEducations",
                newName: "employeeDetailEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeEducations_EmployeeDetailEmployeeId",
                table: "EmployeeEducations",
                newName: "IX_EmployeeEducations_employeeDetailEmployeeId");

            migrationBuilder.AlterColumn<int>(
                name: "employeeDetailEmployeeId",
                table: "EmployeeEducations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEducations_EmployeeDetails_employeeDetailEmployeeId",
                table: "EmployeeEducations",
                column: "employeeDetailEmployeeId",
                principalTable: "EmployeeDetails",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEducations_EmployeeDetails_employeeDetailEmployeeId",
                table: "EmployeeEducations");

            migrationBuilder.RenameColumn(
                name: "employeeDetailEmployeeId",
                table: "EmployeeEducations",
                newName: "EmployeeDetailEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeEducations_employeeDetailEmployeeId",
                table: "EmployeeEducations",
                newName: "IX_EmployeeEducations_EmployeeDetailEmployeeId");

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
