using Microsoft.EntityFrameworkCore;
using Assignment2.TopLayer.Domain;

namespace Assignment2.BottomLayerPersistenceLogic.EntityConfigurations
{
    public class StudentExerciseConfigurations : IEntityTypeConfiguration<StudentExercise>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<StudentExercise> builder)
        {
            builder.HasKey(se => new {se.StudentAUID, se.ExerciseLecture, se.ExerciseNumber});
            builder.HasOne(se => se.Student)
                .WithMany(s => s.StudentExercises)
                .HasForeignKey(se => se.StudentAUID);
            builder.HasOne(se => se.Exercise)
                .WithMany(e => e.StudentExercises)
                .HasForeignKey(se => new { se.ExerciseNumber, se.ExerciseLecture });
        }
    }
}
