using Microsoft.EntityFrameworkCore;
using Assignment2.TopLayer.Domain;

namespace Assignment2.BottomLayerPersistenceLogic.EntityConfigurations
{
    public class AssignmentConfigurations : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Assignment> builder)
        {
            builder.HasOne(a => a.Teacher)
                    .WithMany(t => t.Assignments)
                    .HasForeignKey(a => a.TeacherAUID);

            builder.HasOne(a => a.Course)
                    .WithMany(c => c.Assignments)
                    .HasForeignKey(a => a.CourseID);
        }
    }
}