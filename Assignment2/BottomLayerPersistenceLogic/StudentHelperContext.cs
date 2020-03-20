using Microsoft.EntityFrameworkCore;


namespace DAB_assignment_2.BottomLayerPersistenceLogic
{
    public class StudentHelperContext : DbContext
    {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.ApplyConfigurationsFromAssembly()
    }

    }
}