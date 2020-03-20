using Assignment2.TopLayer.RepositoryInterfaces;
using Assignment2.TopLayer.Domain;
using System.Collections.Generic;

namespace Assignment2.BottomLayerPersistenceLogic.Repositories
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