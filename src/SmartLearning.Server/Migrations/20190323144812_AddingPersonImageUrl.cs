using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartLearning.Server.Migrations
{
    public partial class AddingPersonImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Student",
                nullable: true,maxLength:300);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Student");
        }
    }
}
