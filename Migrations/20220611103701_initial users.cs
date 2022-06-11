using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayrollAPI.Migrations
{
    public partial class initialusers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "educations",
                columns: table => new
                {
                    InstitutionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstitutionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_educations", x => x.InstitutionId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDetails",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeNo = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Citizenship = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdNo = table.Column<int>(type: "int", nullable: false),
                    KRANo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NHIFNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NSSFNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GrossPay = table.Column<decimal>(type: "Decimal (38,2)", nullable: false),
                    NumberOfChildren = table.Column<int>(type: "int", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployerCode = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    EmployerPin = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDetails", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoleType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    RoleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPhone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Logged = table.Column<bool>(type: "bit", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                });

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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
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
                name: "educations");

            migrationBuilder.DropTable(
                name: "EmployeeEducations");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "EmployeeDetails");
        }
    }
}
