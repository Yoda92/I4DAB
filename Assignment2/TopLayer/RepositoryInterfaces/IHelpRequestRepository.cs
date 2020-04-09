using System.Collections;
using System.Collections.Generic;
using Assignment2.TopLayer.Domain;

namespace Assignment2.TopLayer.RepositoryInterfaces
{
    public interface IHelpRequestRepository
    {
        public IEnumerable<StudentAssignment> GetStudentAssignments(string studentId);
    }
}