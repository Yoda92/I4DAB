using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2.Migrations
{
    public partial class AddedCourseIDToCompositePrimaryKeyInExercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentExercises_Exercises_ExerciseNumber_ExerciseLecture",
                table: "StudentExercises");

            migrationBuilder.DropIndex(
                name: "IX_StudentExercises_ExerciseNumber_ExerciseLecture",
                table: "StudentExercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "StudentExercises",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises",
                columns: new[] { "Number", "Lecture", "CourseID" });

            migrationBuilder.UpdateData(
                table: "StudentExercises",
                keyColumns: new[] { "StudentAUID", "ExerciseLecture", "ExerciseNumber" },
                keyValues: new object[] { "au111111", 1, 1 },
                column: "CourseId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "StudentExercises",
                keyColumns: new[] { "StudentAUID", "ExerciseLecture", "ExerciseNumber" },
                keyValues: new object[] { "au222222", 1, 2 },
                column: "CourseId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StudentExercises",
                keyColumns: new[] { "StudentAUID", "ExerciseLecture", "ExerciseNumber" },
                keyValues: new object[] { "au333333", 1, 3 },
                column: "CourseId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_StudentExercises_ExerciseNumber_ExerciseLecture_CourseId",
                table: "StudentExercises",
                columns: new[] { "ExerciseNumber", "ExerciseLecture", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExercises_Exercises_ExerciseNumber_ExerciseLecture_CourseId",
                table: "StudentExercises",
                columns: new[] { "ExerciseNumber", "ExerciseLecture", "CourseId" },
                principalTable: "Exercises",
                principalColumns: new[] { "Number", "Lecture", "CourseID" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentExercises_Exercises_ExerciseNumber_ExerciseLecture_CourseId",
                table: "StudentExercises");

            migrationBuilder.DropIndex(
                name: "IX_StudentExercises_ExerciseNumber_ExerciseLecture_CourseId",
                table: "StudentExercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "StudentExercises");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises",
                columns: new[] { "Number", "Lecture" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentExercises_ExerciseNumber_ExerciseLecture",
                table: "StudentExercises",
                columns: new[] { "ExerciseNumber", "ExerciseLecture" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExercises_Exercises_ExerciseNumber_ExerciseLecture",
                table: "StudentExercises",
                columns: new[] { "ExerciseNumber", "ExerciseLecture" },
                principalTable: "Exercises",
                principalColumns: new[] { "Number", "Lecture" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
