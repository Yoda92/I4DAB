using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2.Migrations
{
    public partial class RebuildDBCauseOfError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Abbreviation = table.Column<string>(nullable: true),
                    AssignmentID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    AUID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.AUID);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    AUID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.AUID);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    StudentAUID = table.Column<string>(nullable: false),
                    CourseID = table.Column<long>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Semester = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.StudentAUID, x.CourseID });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentAUID",
                        column: x => x.StudentAUID,
                        principalTable: "Students",
                        principalColumn: "AUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TeacherAUID = table.Column<string>(nullable: true),
                    CourseID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Assignments_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignments_Teacher_TeacherAUID",
                        column: x => x.TeacherAUID,
                        principalTable: "Teacher",
                        principalColumn: "AUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Lecture = table.Column<long>(nullable: false),
                    Number = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    HelpWhere = table.Column<string>(nullable: true),
                    TeacherAUID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => new { x.Number, x.Lecture });
                    table.ForeignKey(
                        name: "FK_Exercises_Teacher_TeacherAUID",
                        column: x => x.TeacherAUID,
                        principalTable: "Teacher",
                        principalColumn: "AUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCourses",
                columns: table => new
                {
                    TeacherAUID = table.Column<string>(nullable: false),
                    CourseID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourses", x => new { x.TeacherAUID, x.CourseID });
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Teacher_TeacherAUID",
                        column: x => x.TeacherAUID,
                        principalTable: "Teacher",
                        principalColumn: "AUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAssignments",
                columns: table => new
                {
                    StudentAUID = table.Column<string>(nullable: false),
                    AssignmentID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssignments", x => new { x.StudentAUID, x.AssignmentID });
                    table.ForeignKey(
                        name: "FK_StudentAssignments_Assignments_AssignmentID",
                        column: x => x.AssignmentID,
                        principalTable: "Assignments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAssignments_Students_StudentAUID",
                        column: x => x.StudentAUID,
                        principalTable: "Students",
                        principalColumn: "AUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentExercises",
                columns: table => new
                {
                    StudentAUID = table.Column<string>(nullable: false),
                    ExerciseNumber = table.Column<long>(nullable: false),
                    ExerciseLecture = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentExercises", x => new { x.StudentAUID, x.ExerciseLecture, x.ExerciseNumber });
                    table.ForeignKey(
                        name: "FK_StudentExercises_Students_StudentAUID",
                        column: x => x.StudentAUID,
                        principalTable: "Students",
                        principalColumn: "AUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentExercises_Exercises_ExerciseLecture_ExerciseNumber",
                        columns: x => new { x.ExerciseLecture, x.ExerciseNumber },
                        principalTable: "Exercises",
                        principalColumns: new[] { "Number", "Lecture" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CourseID",
                table: "Assignments",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_TeacherAUID",
                table: "Assignments",
                column: "TeacherAUID");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TeacherAUID",
                table: "Exercises",
                column: "TeacherAUID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignments_AssignmentID",
                table: "StudentAssignments",
                column: "AssignmentID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseID",
                table: "StudentCourses",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExercises_ExerciseLecture_ExerciseNumber",
                table: "StudentExercises",
                columns: new[] { "ExerciseLecture", "ExerciseNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_CourseID",
                table: "TeacherCourses",
                column: "CourseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAssignments");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "StudentExercises");

            migrationBuilder.DropTable(
                name: "TeacherCourses");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
