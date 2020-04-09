using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2.Migrations
{
    public partial class RebuildCauseOfError4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
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
                    CourseID = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Semester = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.StudentAUID, x.CourseID });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
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
                    AssignmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherAUID = table.Column<string>(nullable: true),
                    CourseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.AssignmentID);
                    table.ForeignKey(
                        name: "FK_Assignments_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
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
                    Lecture = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
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
                    CourseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourses", x => new { x.TeacherAUID, x.CourseID });
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
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
                    AssignmentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssignments", x => new { x.StudentAUID, x.AssignmentID });
                    table.ForeignKey(
                        name: "FK_StudentAssignments_Assignments_AssignmentID",
                        column: x => x.AssignmentID,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentID",
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
                    ExerciseNumber = table.Column<int>(nullable: false),
                    ExerciseLecture = table.Column<int>(nullable: false)
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
                        name: "FK_StudentExercises_Exercises_ExerciseNumber_ExerciseLecture",
                        columns: x => new { x.ExerciseNumber, x.ExerciseLecture },
                        principalTable: "Exercises",
                        principalColumns: new[] { "Number", "Lecture" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseID", "Name" },
                values: new object[,]
                {
                    { 1, "DAB" },
                    { 2, "GUI" },
                    { 3, "SWD" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "AUID", "Name" },
                values: new object[,]
                {
                    { "au111111", "Anders" },
                    { "au222222", "Lau" },
                    { "au333333", "Christoffer" },
                    { "au444444", "David" }
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "AUID", "Name" },
                values: new object[,]
                {
                    { "au555555", "Arnold Ananas" },
                    { "au666666", "Bob Bodega" },
                    { "au777777", "Clement Citron" }
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "AssignmentID", "CourseID", "TeacherAUID" },
                values: new object[,]
                {
                    { 3, 3, "au777777" },
                    { 2, 2, "au666666" },
                    { 1, 1, "au555555" }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Number", "Lecture", "HelpWhere", "TeacherAUID" },
                values: new object[,]
                {
                    { 2, 1, "Benjamin", "au666666" },
                    { 1, 1, "Benjamin", "au555555" },
                    { 3, 1, "Benjamin", "au777777" }
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "StudentAUID", "CourseID", "IsActive", "Semester" },
                values: new object[,]
                {
                    { "au111111", 1, false, 0 },
                    { "au444444", 3, false, 0 },
                    { "au444444", 1, false, 0 },
                    { "au444444", 2, false, 0 },
                    { "au333333", 2, false, 0 },
                    { "au333333", 1, false, 0 },
                    { "au222222", 3, false, 0 },
                    { "au222222", 2, false, 0 },
                    { "au222222", 1, false, 0 },
                    { "au111111", 3, false, 0 },
                    { "au111111", 2, false, 0 },
                    { "au333333", 3, false, 0 }
                });

            migrationBuilder.InsertData(
                table: "TeacherCourses",
                columns: new[] { "TeacherAUID", "CourseID" },
                values: new object[,]
                {
                    { "au555555", 1 },
                    { "au666666", 2 },
                    { "au777777", 3 }
                });

            migrationBuilder.InsertData(
                table: "StudentAssignments",
                columns: new[] { "StudentAUID", "AssignmentID" },
                values: new object[,]
                {
                    { "au111111", 1 },
                    { "au111111", 2 },
                    { "au111111", 3 }
                });

            migrationBuilder.InsertData(
                table: "StudentExercises",
                columns: new[] { "StudentAUID", "ExerciseLecture", "ExerciseNumber" },
                values: new object[,]
                {
                    { "au111111", 1, 1 },
                    { "au222222", 1, 2 },
                    { "au333333", 1, 3 }
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
                name: "IX_StudentExercises_ExerciseNumber_ExerciseLecture",
                table: "StudentExercises",
                columns: new[] { "ExerciseNumber", "ExerciseLecture" });

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
