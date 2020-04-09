using Assignment2.TopLayer.Domain;
using System.Collections.Generic;

namespace Assignment2.TopLayer.RepositoryInterfaces
{
    public interface IAssignmentRepository : IRepository<Assignment>
    {
        IEnumerable<Assignment> GetAssignmentsWithHelpRequestsByStudent(Student student);
        IEnumerable<Assignment> GetAssignmentsByCourse(Course course);

    }
}