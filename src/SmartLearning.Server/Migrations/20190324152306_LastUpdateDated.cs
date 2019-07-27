using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartLearning.Server.Migrations
{
    public partial class LastUpdateDated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "Student",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Student");
        }
    }
}
