using System;
using Microsoft.EntityFrameworkCore;
using Assignment2.TopLayer.Domain;


namespace Assignment2.BottomLayerPersistenceLogic
{
    public class StudentHelperContext : DbContext
    {

        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teacher { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-BL1CI2M;Initial Catalog=HelpRequestDB;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfigurationsFromAssembly()
        }

        }
}