using Microsoft.EntityFrameworkCore;
using Assignment2.TopLayer.Domain;

namespace Assignment2.BottomLayerPersistenceLogic.EntityConfigurations
{
    public class StudentAssignmentConfigurations : IEntityTypeConfiguration<StudentAssignment>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<StudentAssignment> builder)
        {
            builder.HasKey(s => new{ s.StudentAUID, s.AssignmentID });
        }
    }
}