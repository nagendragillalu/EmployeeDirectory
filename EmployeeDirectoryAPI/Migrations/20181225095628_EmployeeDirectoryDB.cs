using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeDirectoryAPI.Migrations
{
    public partial class EmployeeDirectoryDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailID",
                table: "Employees",
                maxLength: 300,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailID",
                table: "Employees");
        }
    }
}
