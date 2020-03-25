using Microsoft.EntityFrameworkCore;
using Assignment2.TopLayer.Domain;

namespace Assignment2.BottomLayerPersistenceLogic.EntityConfigurations
{
    public class TeacherCourseConfigurations : IEntityTypeConfiguration<TeacherCourse>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TeacherCourse> builder)
        {
            builder.HasKey(t => new{ t.TeacherAUID, t.CourseID });
        }
    }
}