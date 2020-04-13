using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2.Migrations
{
    public partial class AddedCourseIDtoExercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "Exercises",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumns: new[] { "Number", "Lecture" },
                keyValues: new object[] { 1, 1 },
                column: "CourseID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumns: new[] { "Number", "Lecture" },
                keyValues: new object[] { 2, 1 },
                column: "CourseID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumns: new[] { "Number", "Lecture" },
                keyValues: new object[] { 3, 1 },
                column: "CourseID",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_CourseID",
                table: "Exercises",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Courses_CourseID",
                table: "Exercises",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Courses_CourseID",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_CourseID",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "Exercises");
        }
    }
}
