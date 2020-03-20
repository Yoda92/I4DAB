using DAB_assignment_2.TopLayer.RepositoryInterfaces;
using DAB_assignment_2.TopLayer.Domain;
using System.Collections.Generic;

namespace DAB_assignment_2.BottomLayerPersistenceLogic.Repositories
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(StudentHelperContext context) : base(context)
        {
            
        }
        
    }
}