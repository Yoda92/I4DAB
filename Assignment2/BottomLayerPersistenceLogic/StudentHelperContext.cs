using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Assignment2.TopLayer.Domain;
using Assignment2.BottomLayerPersistenceLogic.EntityConfigurations;

namespace Assignment2.BottomLayerPersistenceLogic
{
    public class StudentHelperContext : DbContext
    {
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<StudentAssignment> StudentAssignments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet <StudentCourse> StudentCourses { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet <TeacherCourse> TeacherCourses { get; set; }
        public DbSet<StudentExercise> StudentExercises { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("StudentHelperDB"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AssignmentConfigurations());
            modelBuilder.ApplyConfiguration(new CourseConfigurations());
            modelBuilder.ApplyConfiguration(new StudentConfigurations());
            modelBuilder.ApplyConfiguration(new TeacherConfigurations());
            modelBuilder.ApplyConfiguration(new StudentAssignmentConfigurations());
            modelBuilder.ApplyConfiguration(new StudentCourseConfigurations());
            modelBuilder.ApplyConfiguration(new TeacherCourseConfigurations());
            modelBuilder.ApplyConfiguration(new ExerciseConfigurations());
            modelBuilder.ApplyConfiguration(new StudentExerciseConfigurations());

            // Courses
            modelBuilder.Entity<Course>().HasData(new Course
                { CourseID = 1, Name = "DAB" });
            modelBuilder.Entity<Course>().HasData(new Course
                { CourseID = 2, Name = "GUI" });
            modelBuilder.Entity<Course>().HasData(new Course
                { CourseID = 3, Name = "SWD" });

            // Teachers
            modelBuilder.Entity<Teacher>().HasData(new Teacher
                { AUID = "au555555", Name = "Arnold Ananas" });
            modelBuilder.Entity<Teacher>().HasData(new Teacher
                { AUID = "au666666", Name = "Bob Bodega" });
            modelBuilder.Entity<Teacher>().HasData(new Teacher
                { AUID = "au777777", Name = "Clement Citron" });

            // Students
            modelBuilder.Entity<Student>().HasData(new Student
                { AUID = "au111111", Name = "Anders" });
            modelBuilder.Entity<Student>().HasData(new Student
                { AUID = "au222222", Name = "Lau" });
            modelBuilder.Entity<Student>().HasData(new Student
                { AUID = "au333333", Name = "Christoffer" });
            modelBuilder.Entity<Student>().HasData(new Student
                { AUID = "au444444", Name = "David" });

            // Exercises
            modelBuilder.Entity<Exercise>().HasData(new Exercise
                {HelpWhere = "Benjamin", Lecture = 1, Number = 1, TeacherAUID = "au555555" });
            modelBuilder.Entity<Exercise>().HasData(new Exercise
                { HelpWhere = "Benjamin", Lecture = 1, Number = 2, TeacherAUID = "au666666" });
            modelBuilder.Entity<Exercise>().HasData(new Exercise
                { HelpWhere = "Benjamin", Lecture = 1, Number = 3, TeacherAUID = "au777777" });

            // Assignments
            modelBuilder.Entity<Assignment>().HasData(new Assignment
                { AssignmentID = 1, CourseID = 1, TeacherAUID = "au555555" });
            modelBuilder.Entity<Assignment>().HasData(new Assignment
                { AssignmentID = 2, CourseID = 2, TeacherAUID = "au666666" });
            modelBuilder.Entity<Assignment>().HasData(new Assignment
                { AssignmentID = 3, CourseID = 3, TeacherAUID = "au777777" });

            // TeacherCourses
            modelBuilder.Entity<TeacherCourse>().HasData(new TeacherCourse
                { TeacherAUID = "au555555", CourseID = 1 });
            modelBuilder.Entity<TeacherCourse>().HasData(new TeacherCourse
                { TeacherAUID = "au666666", CourseID = 2 });
            modelBuilder.Entity<TeacherCourse>().HasData(new TeacherCourse
                { TeacherAUID = "au777777", CourseID = 3 });

            // StudentAssignments
            modelBuilder.Entity<StudentAssignment>().HasData(new StudentAssignment
                { AssignmentID = 1, StudentAUID = "au111111" });
            modelBuilder.Entity<StudentAssignment>().HasData(new StudentAssignment
                { AssignmentID = 2, StudentAUID = "au111111" });
            modelBuilder.Entity<StudentAssignment>().HasData(new StudentAssignment
                { AssignmentID = 3, StudentAUID = "au111111" });

            // StudentExercises
             modelBuilder.Entity<StudentExercise>().HasData(new StudentExercise
                { ExerciseLecture = 1, ExerciseNumber = 1, StudentAUID = "au111111" });
             modelBuilder.Entity<StudentExercise>().HasData(new StudentExercise 
              { ExerciseLecture = 1, ExerciseNumber = 2, StudentAUID = "au222222" });
             modelBuilder.Entity<StudentExercise>().HasData(new StudentExercise
                { ExerciseLecture = 1, ExerciseNumber = 3, StudentAUID = "au333333" });

            // StudentCourses
            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse
                {StudentAUID = "au111111", CourseID = 1});
            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse
                { StudentAUID = "au111111", CourseID = 2 });
            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse
                { StudentAUID = "au111111", CourseID = 3 });

            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse
                { StudentAUID = "au222222", CourseID = 1 });
            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse
                { StudentAUID = "au222222", CourseID = 2 });
            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse
                { StudentAUID = "au222222", CourseID = 3 });

            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse
                { StudentAUID = "au333333", CourseID = 1 });
            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse
                { StudentAUID = "au333333", CourseID = 2 });
            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse
                { StudentAUID = "au333333", CourseID = 3 });

            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse
                { StudentAUID = "au444444", CourseID = 1 });
            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse
                { StudentAUID = "au444444", CourseID = 2 });
            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse
                { StudentAUID = "au444444", CourseID = 3 });
        }

    }
}