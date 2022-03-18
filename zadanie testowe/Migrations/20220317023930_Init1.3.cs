using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace zadanie_testowe.Migrations
{
    public partial class Init13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TimeToExpiry",
                table: "Tasks",
                type: "double",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(6)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TimeToExpiry",
                table: "Tasks",
                type: "time(6)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");
        }
    }
}
