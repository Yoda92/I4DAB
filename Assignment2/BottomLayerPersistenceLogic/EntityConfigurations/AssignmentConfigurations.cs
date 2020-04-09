using Microsoft.EntityFrameworkCore;
using Assignment2.TopLayer.Domain;

namespace Assignment2.BottomLayerPersistenceLogic.EntityConfigurations
{
    public class AssignmentConfigurations : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Assignment> builder)
        {
            builder.HasKey(a => a.AssignmentID);
        }
    }
}