using Assignment2.TopLayer.RepositoryInterfaces;
using Assignment2.TopLayer.Domain;
using System.Collections.Generic;

namespace Assignment2.BottomLayerPersistenceLogic.Repositories
{
    public class LectureRepository : Repository<Lecture>, ILectureRepository
    {
        public LectureRepository(StudentHelperContext context) : base(context)
        {
            
        }
        
    }
}