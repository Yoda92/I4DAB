using DAB_assignment_2.TopLayer.RepositoryInterfaces;
using DAB_assignment_2.TopLayer.Domain;
using System.Collections.Generic;

namespace DAB_assignment_2.BottomLayerPersistenceLogic.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(StudentHelperContext context) : base(context)
        {  
        }

        public void AssistanceIsCompleted(uint StudentID)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Student> GetStudentsNeedingAssistance()
        {
            throw new System.NotImplementedException();
        }
    }
}