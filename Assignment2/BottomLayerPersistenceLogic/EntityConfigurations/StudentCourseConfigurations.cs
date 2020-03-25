using Microsoft.EntityFrameworkCore;
using Assignment2.TopLayer.Domain;

namespace Assignment2.BottomLayerPersistenceLogic.EntityConfigurations
{
    public class StudentCourseConfigurations : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(s => new{ s.StudentAUID, s.CourseID });
            builder.HasOne(sa => sa.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sa => sa.StudentAUID);

            builder.HasOne(sa => sa.Course)
                .WithMany(a => a.StudentsAttending)
                .HasForeignKey(sa => sa.CourseID);
        }
    }
}