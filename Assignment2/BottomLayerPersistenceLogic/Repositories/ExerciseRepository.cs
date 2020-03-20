using Assignment2.TopLayer.RepositoryInterfaces;
using Assignment2.TopLayer.Domain;
using System.Collections.Generic;

namespace Assignment2.BottomLayerPersistenceLogic.Repositories
{
    public class ExerciseRepository : Repository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(StudentHelperContext context) : base(context)
        {
            
        }
        
    }
}