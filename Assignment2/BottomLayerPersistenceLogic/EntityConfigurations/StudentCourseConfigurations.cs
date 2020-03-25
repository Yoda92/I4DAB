using Microsoft.EntityFrameworkCore;
using Assignment2.TopLayer.Domain;

namespace Assignment2.BottomLayerPersistenceLogic.EntityConfigurations
{
    public class StudentCourseConfigurations : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(s => new{ s.StudentAUID, s.CourseID });
            builder.HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentAUID);

            builder.HasOne(sc => sc.Course)
                .WithMany(a => a.StudentsAttending)
                .HasForeignKey(sc => sc.CourseID);
        }
    }
}