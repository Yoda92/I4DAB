using System;
using Microsoft.EntityFrameworkCore;


namespace Assignment2.BottomLayerPersistenceLogic
{
    public class StudentHelperContext : DbContext
    {
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