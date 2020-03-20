using DAB_assignment_2.TopLayer.RepositoryInterfaces;
using DAB_assignment_2.TopLayer.Domain;
using System.Collections.Generic;

namespace DAB_assignment_2.BottomLayerPersistenceLogic.Repositories
{
    public class LectureRepository : Repository<Lecture>, ILectureRepository
    {
        public LectureRepository(StudentHelperContext context) : base(context)
        {
            
        }
        
    }
}