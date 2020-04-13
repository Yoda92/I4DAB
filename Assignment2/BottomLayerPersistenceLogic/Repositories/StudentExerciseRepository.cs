using Assignment2.TopLayer.RepositoryInterfaces;
using Assignment2.TopLayer.Domain;
using System.Collections.Generic;

namespace Assignment2.BottomLayerPersistenceLogic.Repositories
{
    public class StudentExerciseRepository : Repository<StudentExercise>, IStudentExerciseRepository
    {
        public StudentExerciseRepository(StudentHelperContext context) : base(context)
        {

        }
    }
}