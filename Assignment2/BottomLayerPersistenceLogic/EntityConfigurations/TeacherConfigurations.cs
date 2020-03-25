using Microsoft.EntityFrameworkCore;
using Assignment2.TopLayer.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment2.BottomLayerPersistenceLogic.EntityConfigurations
{
    public class TeacherConfigurations : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(t => t.AUID);

            
            
        }
    }
}