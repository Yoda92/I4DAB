using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2.Migrations
{
    public partial class initialmigration : Migration
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
                    AssignmentID = table.Column<long>(nullable: false),
                    LectureID = table.Column<long>(nullable: false)
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
                    Name = table.Column<string>(nullable: true),
                    CurrentSemester = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.AUID);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CourseID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lectures_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourse",
                columns: table => new
                {
                    StudentAUID = table.Column<string>(nullable: false),
                    CourseID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourse", x => new { x.StudentAUID, x.CourseID });
                    table.ForeignKey(
                        name: "FK_StudentCourse_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Students_StudentAUID",
                        column: x => x.StudentAUID,
                        principalTable: "Students",
                        principalColumn: "AUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAssignment",
                columns: table => new
                {
                    StudentAUID = table.Column<long>(nullable: false),
                    AssignmentID = table.Column<long>(nullable: false),
                    StudentAUID1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssignment", x => new { x.StudentAUID, x.AssignmentID });
                    table.ForeignKey(
                        name: "FK_StudentAssignment_Assignments_AssignmentID",
                        column: x => x.AssignmentID,
                        principalTable: "Assignments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAssignment_Students_StudentAUID1",
                        column: x => x.StudentAUID1,
                        principalTable: "Students",
                        principalColumn: "AUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LectureID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Exercises_Lectures_LectureID",
                        column: x => x.LectureID,
                        principalTable: "Lectures",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentExercise",
                columns: table => new
                {
                    StudentAUID = table.Column<long>(nullable: false),
                    ExerciseID = table.Column<long>(nullable: false),
                    StudentAUID1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentExercise", x => new { x.StudentAUID, x.ExerciseID });
                    table.ForeignKey(
                        name: "FK_StudentExercise_Exercises_ExerciseID",
                        column: x => x.ExerciseID,
                        principalTable: "Exercises",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentExercise_Students_StudentAUID1",
                        column: x => x.StudentAUID1,
                        principalTable: "Students",
                        principalColumn: "AUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    AUID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ExerciseID = table.Column<long>(nullable: true),
                    AssignmentID = table.Column<long>(nullable: true),
                    AuidOfStudentBeingAssisted = table.Column<long>(nullable: false),
                    StudentAUID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.AUID);
                    table.ForeignKey(
                        name: "FK_Teacher_Assignments_AssignmentID",
                        column: x => x.AssignmentID,
                        principalTable: "Assignments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teacher_Exercises_ExerciseID",
                        column: x => x.ExerciseID,
                        principalTable: "Exercises",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teacher_Students_StudentAUID",
                        column: x => x.StudentAUID,
                        principalTable: "Students",
                        principalColumn: "AUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCourse",
                columns: table => new
                {
                    TeacherAUID = table.Column<string>(nullable: false),
                    CourseID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourse", x => new { x.TeacherAUID, x.CourseID });
                    table.ForeignKey(
                        name: "FK_TeacherCourse_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherCourse_Teacher_TeacherAUID",
                        column: x => x.TeacherAUID,
                        principalTable: "Teacher",
                        principalColumn: "AUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CourseID",
                table: "Assignments",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_LectureID",
                table: "Exercises",
                column: "LectureID");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_CourseID",
                table: "Lectures",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignment_AssignmentID",
                table: "StudentAssignment",
                column: "AssignmentID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignment_StudentAUID1",
                table: "StudentAssignment",
                column: "StudentAUID1");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_CourseID",
                table: "StudentCourse",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExercise_ExerciseID",
                table: "StudentExercise",
                column: "ExerciseID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExercise_StudentAUID1",
                table: "StudentExercise",
                column: "StudentAUID1");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_AssignmentID",
                table: "Teacher",
                column: "AssignmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_ExerciseID",
                table: "Teacher",
                column: "ExerciseID");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_StudentAUID",
                table: "Teacher",
                column: "StudentAUID");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourse_CourseID",
                table: "TeacherCourse",
                column: "CourseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAssignment");

            migrationBuilder.DropTable(
                name: "StudentCourse");

            migrationBuilder.DropTable(
                name: "StudentExercise");

            migrationBuilder.DropTable(
                name: "TeacherCourse");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
