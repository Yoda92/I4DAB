using DAB_assignment_2.TopLayer.RepositoryInterfaces;
using DAB_assignment_2.TopLayer.Domain;
using System.Collections.Generic;

namespace DAB_assignment_2.BottomLayerPersistenceLogic.Repositories
{
    public class AssignmentRepository : Repository<Assignment>, IAssignmentRepository
    {
        public AssignmentRepository(StudentHelperContext context) : base(context)
        {
        }
        
        public IEnumerable<Assignment> GetAssignmentsByCourse(Course course)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Assignment> GetAssignmentsWithHelpRequestsByStudent(Student student)
        {
            throw new System.NotImplementedException();
        }
    }
}