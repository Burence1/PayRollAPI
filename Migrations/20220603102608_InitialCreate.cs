using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayrollAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    PhoneNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdNo = table.Column<int>(type: "int", nullable: false),
                    KRANo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NHIFNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NSSFNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GrossPay = table.Column<decimal>(type: "Decimal (38,2)", nullable: false),
                    NumberOfChildren = table.Column<int>(type: "int", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployerCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDetails", x => x.EmployeeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDetails");
        }
    }
}
