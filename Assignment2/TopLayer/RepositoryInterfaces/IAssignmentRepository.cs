using Assignment2.TopLayer.Domain;
using System.Collections.Generic;

namespace Assignment2.TopLayer.RepositoryInterfaces
{
    public interface IAssignmentRepository
    {
        IEnumerable<Assignment> GetAssignmentsWithHelpRequestsByStudent(Student student);
        IEnumerable<Assignment> GetAssignmentsByCourse(Course course);

    }
}