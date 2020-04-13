using Assignment2.TopLayer.RepositoryInterfaces;
using Assignment2.TopLayer.Domain;
using System.Collections.Generic;

namespace Assignment2.BottomLayerPersistenceLogic.Repositories
{
    public class StudentAssignmentRepository : Repository<StudentAssignment>, IStudentAssignmentRepository 
    {
        public StudentAssignmentRepository(StudentHelperContext context) : base(context)
        {

        }
    }
}