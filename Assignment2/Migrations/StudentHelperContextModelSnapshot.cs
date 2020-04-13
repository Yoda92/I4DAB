﻿// <auto-generated />
using Assignment2.BottomLayerPersistenceLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Assignment2.Migrations
{
    [DbContext(typeof(StudentHelperContext))]
    partial class StudentHelperContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Assignment2.TopLayer.Domain.Assignment", b =>
                {
                    b.Property<int>("AssignmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssignmentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<string>("TeacherAUID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AssignmentID");

                    b.HasIndex("CourseID");

                    b.HasIndex("TeacherAUID");

                    b.ToTable("Assignments");

                    b.HasData(
                        new
                        {
                            AssignmentID = 1,
                            AssignmentName = "DAB assignment 2 (extreme difficulty)",
                            CourseID = 1,
                            TeacherAUID = "au555555"
                        },
                        new
                        {
                            AssignmentID = 2,
                            AssignmentName = "Hjemmeside der appellerer til unge mennesker",
                            CourseID = 2,
                            TeacherAUID = "au666666"
                        },
                        new
                        {
                            AssignmentID = 3,
                            AssignmentName = "Become DK Elon Musk",
                            CourseID = 3,
                            TeacherAUID = "au777777"
                        });
                });

            modelBuilder.Entity("Assignment2.TopLayer.Domain.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseID");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseID = 1,
                            Name = "DAB"
                        },
                        new
                        {
                            CourseID = 2,
                            Name = "GUI"
                        },
                        new
                        {
                            CourseID = 3,
                            Name = "SWD"
                        });
                });

            modelBuilder.Entity("Assignment2.TopLayer.Domain.Exercise", b =>
                {
                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("Lecture")
                        .HasColumnType("int");

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<string>("HelpWhere")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherAUID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Number", "Lecture", "CourseID");

                    b.HasIndex("CourseID");

                    b.HasIndex("TeacherAUID");

                    b.ToTable("Exercises");

                    b.HasData(
                        new
                        {
                            Number = 1,
                            Lecture = 1,
                            CourseID = 1,
                            HelpWhere = "Benjamin",
                            TeacherAUID = "au555555"
                        },
                        new
                        {
                            Number = 2,
                            Lecture = 1,
                            CourseID = 2,
                            HelpWhere = "Benjamin",
                            TeacherAUID = "au666666"
                        },
                        new
                        {
                            Number = 3,
                            Lecture = 1,
                            CourseID = 3,
                            HelpWhere = "Benjamin",
                            TeacherAUID = "au777777"
                        });
                });

            modelBuilder.Entity("Assignment2.TopLayer.Domain.Student", b =>
                {
                    b.Property<string>("AUID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AUID");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            AUID = "au111111",
                            Name = "Anders"
                        },
                        new
                        {
                            AUID = "au222222",
                            Name = "Lau"
                        },
                        new
                        {
                            AUID = "au333333",
                            Name = "Christoffer"
                        },
                        new
                        {
                            AUID = "au444444",
                            Name = "David"
                        });
                });

            modelBuilder.Entity("Assignment2.TopLayer.Domain.StudentAssignment", b =>
                {
                    b.Property<string>("StudentAUID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AssignmentID")
                        .HasColumnType("int");

                    b.Property<bool>("IsOpen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("StudentAUID", "AssignmentID");

                    b.HasIndex("AssignmentID");

                    b.ToTable("StudentAssignments");

                    b.HasData(
                        new
                        {
                            StudentAUID = "au111111",
                            AssignmentID = 1,
                            IsOpen = false
                        },
                        new
                        {
                            StudentAUID = "au111111",
                            AssignmentID = 2,
                            IsOpen = false
                        },
                        new
                        {
                            StudentAUID = "au111111",
                            AssignmentID = 3,
                            IsOpen = false
                        });
                });

            modelBuilder.Entity("Assignment2.TopLayer.Domain.StudentCourse", b =>
                {
                    b.Property<string>("StudentAUID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.HasKey("StudentAUID", "CourseID");

                    b.HasIndex("CourseID");

                    b.ToTable("StudentCourses");

                    b.HasData(
                        new
                        {
                            StudentAUID = "au111111",
                            CourseID = 1,
                            IsActive = false,
                            Semester = 0
                        },
                        new
                        {
                            StudentAUID = "au111111",
                            CourseID = 2,
                            IsActive = false,
                            Semester = 0
                        },
                        new
                        {
                            StudentAUID = "au111111",
                            CourseID = 3,
                            IsActive = false,
                            Semester = 0
                        },
                        new
                        {
                            StudentAUID = "au222222",
                            CourseID = 1,
                            IsActive = false,
                            Semester = 0
                        },
                        new
                        {
                            StudentAUID = "au222222",
                            CourseID = 2,
                            IsActive = false,
                            Semester = 0
                        },
                        new
                        {
                            StudentAUID = "au222222",
                            CourseID = 3,
                            IsActive = false,
                            Semester = 0
                        },
                        new
                        {
                            StudentAUID = "au333333",
                            CourseID = 1,
                            IsActive = false,
                            Semester = 0
                        },
                        new
                        {
                            StudentAUID = "au333333",
                            CourseID = 2,
                            IsActive = false,
                            Semester = 0
                        },
                        new
                        {
                            StudentAUID = "au333333",
                            CourseID = 3,
                            IsActive = false,
                            Semester = 0
                        },
                        new
                        {
                            StudentAUID = "au444444",
                            CourseID = 1,
                            IsActive = false,
                            Semester = 0
                        },
                        new
                        {
                            StudentAUID = "au444444",
                            CourseID = 2,
                            IsActive = false,
                            Semester = 0
                        },
                        new
                        {
                            StudentAUID = "au444444",
                            CourseID = 3,
                            IsActive = false,
                            Semester = 0
                        });
                });

            modelBuilder.Entity("Assignment2.TopLayer.Domain.StudentExercise", b =>
                {
                    b.Property<string>("StudentAUID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ExerciseLecture")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseNumber")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<bool>("IsOpen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("StudentAUID", "ExerciseLecture", "ExerciseNumber");

                    b.HasIndex("ExerciseNumber", "ExerciseLecture", "CourseId");

                    b.ToTable("StudentExercises");

                    b.HasData(
                        new
                        {
                            StudentAUID = "au111111",
                            ExerciseLecture = 1,
                            ExerciseNumber = 1,
                            CourseId = 1,
                            IsOpen = false
                        },
                        new
                        {
                            StudentAUID = "au222222",
                            ExerciseLecture = 1,
                            ExerciseNumber = 2,
                            CourseId = 2,
                            IsOpen = false
                        },
                        new
                        {
                            StudentAUID = "au333333",
                            ExerciseLecture = 1,
                            ExerciseNumber = 3,
                            CourseId = 3,
                            IsOpen = false
                        });
                });

            modelBuilder.Entity("Assignment2.TopLayer.Domain.Teacher", b =>
                {
                    b.Property<string>("AUID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AUID");

                    b.ToTable("Teacher");

                    b.HasData(
                        new
                        {
                            AUID = "au555555",
                            Name = "Arnold Ananas"
                        },
                        new
                        {
                            AUID = "au123456",
                            Name = "Hubert Gungadiño"
                        },
                        new
                        {
                            AUID = "au666666",
                            Name = "Bob Bodega"
                        },
                        new
                        {
                            AUID = "au777777",
                            Name = "Clement Citron"
                        });
                });

            modelBuilder.Entity("Assignment2.TopLayer.Domain.TeacherCourse", b =>
                {
                    b.Property<string>("TeacherAUID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.HasKey("TeacherAUID", "CourseID");

                    b.HasIndex("CourseID");

                    b.ToTable("TeacherCourses");

                    b.HasData(
                        new
                        {
                            TeacherAUID = "au555555",
                            CourseID = 1
                        },
                        new
                        {
                            TeacherAUID = "au666666",
                            CourseID = 2
                        },
                        new
                        {
                            TeacherAUID = "au777777",
                            CourseID = 3
                        });
                });

            modelBuilder.Entity("Assignment2.TopLayer.Domain.Assignment", b =>
                {
                    b.HasOne("Assignment2.TopLayer.Domain.Course", "Course")
                        .WithMany("Assignments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment2.TopLayer.Domain.Teacher", "Teacher")
                        .WithMany("Assignments")
                        .HasForeignKey("TeacherAUID");
                });

            modelBuilder.Entity("Assignment2.TopLayer.Domain.Exercise", b =>
                {
                    b.HasOne("Assignment2.TopLayer.Domain.Course", "Course")
                        .WithMany("Exercises")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment2.TopLayer.Domain.Teacher", "Teacher")
                        .WithMany("Exercises")
                        .HasForeignKey("TeacherAUID");
                });

            modelBuilder.Entity("Assignment2.TopLayer.Domain.StudentAssignment", b =>
                {
                    b.HasOne("Assignment2.TopLayer.Domain.Assignment", "Assignment")
                        .WithMany("StudentAssignment")
                        .HasForeignKey("AssignmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment2.TopLayer.Domain.Student", "Student")
                        .WithMany("StudentAssignments")
                        .HasForeignKey("StudentAUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Assignment2.TopLayer.Domain.StudentCourse", b =>
                {
                    b.HasOne("Assignment2.TopLayer.Domain.Course", "Course")
                        .WithMany("StudentsAttending")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment2.TopLayer.Domain.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentAUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Assignment2.TopLayer.Domain.StudentExercise", b =>
                {
                    b.HasOne("Assignment2.TopLayer.Domain.Student", "Student")
                        .WithMany("StudentExercises")
                        .HasForeignKey("StudentAUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment2.TopLayer.Domain.Exercise", "Exercise")
                        .WithMany("StudentExercises")
                        .HasForeignKey("ExerciseNumber", "ExerciseLecture", "CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Assignment2.TopLayer.Domain.TeacherCourse", b =>
                {
                    b.HasOne("Assignment2.TopLayer.Domain.Course", "Course")
                        .WithMany("TeachersResponsible")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment2.TopLayer.Domain.Teacher", "Teacher")
                        .WithMany("ResponsibleForTheseCourses")
                        .HasForeignKey("TeacherAUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
