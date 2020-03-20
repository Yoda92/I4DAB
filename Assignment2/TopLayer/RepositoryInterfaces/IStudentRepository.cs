using System.Collections.Generic;
using DAB_assignment_2.TopLayer.Domain;

namespace DAB_assignment_2.TopLayer.RepositoryInterfaces
{
    public interface IStudentRepository
    {
         IEnumerable<Student> GetStudentsNeedingAssistance();
         void AssistanceIsCompleted(uint StudentID);
    }
}