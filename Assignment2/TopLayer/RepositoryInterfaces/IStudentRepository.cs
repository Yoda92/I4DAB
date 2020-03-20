using System.Collections.Generic;
using Assignment2.TopLayer.Domain;

namespace Assignment2.TopLayer.RepositoryInterfaces
{
    public interface IStudentRepository
    {
         IEnumerable<Student> GetStudentsNeedingAssistance();
         void AssistanceIsCompleted(uint StudentID);
    }
}