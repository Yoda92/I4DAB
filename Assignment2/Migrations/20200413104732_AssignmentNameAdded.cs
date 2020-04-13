using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2.Migrations
{
    public partial class AssignmentNameAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "AssignmentName",
                table: "Assignments",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "AssignmentID",
                keyValue: 1,
                column: "AssignmentName",
                value: "DAB assignment 2 (extreme difficulty)");

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "AssignmentID",
                keyValue: 2,
                column: "AssignmentName",
                value: "Hjemmeside der appellerer til unge mennesker");

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "AssignmentID",
                keyValue: 3,
                column: "AssignmentName",
                value: "Become DK Elon Musk");

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "AUID", "Name" },
                values: new object[] { "au123456", "Hubert Gungadiño" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teacher",
                keyColumn: "AUID",
                keyValue: "au123456");

            migrationBuilder.DropColumn(
                name: "AssignmentName",
                table: "Assignments");


        }
    }
}
