using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartLearning.Server.Migrations
{
    public partial class NameLengthChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Student",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Student",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Student",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Student",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);
        }
    }
}
