using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2.Migrations
{
    public partial class AddedIsOpen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOpen",
                table: "StudentExercises",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOpen",
                table: "StudentAssignments",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOpen",
                table: "StudentExercises");

            migrationBuilder.DropColumn(
                name: "IsOpen",
                table: "StudentAssignments");
        }
    }
}
