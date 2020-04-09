using System.Collections.Generic;
using Assignment2.TopLayer.Domain;

namespace Assignment2.TopLayer.RepositoryInterfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
         IEnumerable<Student> GetStudentsNeedingAssistance();
         void AssistanceIsCompleted(uint StudentID);
    }
}