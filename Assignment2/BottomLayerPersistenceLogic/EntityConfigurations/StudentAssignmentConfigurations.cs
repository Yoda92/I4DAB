using Microsoft.EntityFrameworkCore;
using Assignment2.TopLayer.Domain;

namespace Assignment2.BottomLayerPersistenceLogic.EntityConfigurations
{
    public class StudentAssignmentConfigurations : IEntityTypeConfiguration<StudentAssignment>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<StudentAssignment> builder)
        {
            builder.Property(p => p.IsOpen)
                .HasDefaultValue(true);
            builder.HasKey(sa => new{ sa.StudentAUID, sa.AssignmentID });
            builder.HasOne(sa => sa.Student)
                    .WithMany(s => s.StudentAssignments)
                    .HasForeignKey(sa => sa.StudentAUID);

            builder.HasOne(sa => sa.Assignment)
                    .WithMany(a => a.StudentAssignment)
                    .HasForeignKey(sa => sa.AssignmentID);
        }
    }
}