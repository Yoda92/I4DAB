using Microsoft.EntityFrameworkCore;
using Assignment2.TopLayer.Domain;

namespace Assignment2.BottomLayerPersistenceLogic.EntityConfigurations
{
    public class StudentExerciseConfigurations : IEntityTypeConfiguration<StudentExercise>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<StudentExercise> builder)
        {
            builder.HasKey(s => new{ s.StudentAUID, s.ExerciseID });
        }
    }
}