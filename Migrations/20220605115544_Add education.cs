using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayrollAPI.Migrations
{
    public partial class Addeducation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "EmployeeDetails",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16);

            migrationBuilder.CreateTable(
                name: "EmployeeEducations",
                columns: table => new
                {
                    EducationHistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstitutionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    institutionCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    joinDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    endDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fieldOfStudy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Score = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeDetailEmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEducations", x => x.EducationHistId);
                    table.ForeignKey(
                        name: "FK_EmployeeEducations_EmployeeDetails_EmployeeDetailEmployeeId",
                        column: x => x.EmployeeDetailEmployeeId,
                        principalTable: "EmployeeDetails",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEducations_EmployeeDetailEmployeeId",
                table: "EmployeeEducations",
                column: "EmployeeDetailEmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeEducations");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "EmployeeDetails",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);
        }
    }
}
