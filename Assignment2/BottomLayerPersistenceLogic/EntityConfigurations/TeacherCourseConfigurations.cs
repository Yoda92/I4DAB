using Microsoft.EntityFrameworkCore;
using Assignment2.TopLayer.Domain;

namespace Assignment2.BottomLayerPersistenceLogic.EntityConfigurations
{
    public class TeacherCourseConfigurations : IEntityTypeConfiguration<TeacherCourse>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TeacherCourse> builder)
        {
            builder.HasKey(tc => new{ tc.TeacherAUID, tc.CourseID });
            builder.HasOne(tc => tc.Teacher)
                .WithMany(t => t.ResponsibleForTheseCourses)
                .HasForeignKey(tc => tc.TeacherAUID);
            builder.HasOne(tc => tc.Course)
                .WithMany(c => c.TeachersResponsible)
                .HasForeignKey(tc => tc.CourseID);
        }
    }
}