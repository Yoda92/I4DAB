using System;
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
        }

        }
}