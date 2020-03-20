using DAB_assignment_2.TopLayer.Domain;
using System.Collections.Generic;

namespace DAB_assignment_2.TopLayer.RepositoryInterfaces
{
    public interface IAssignmentRepository
    {
        IEnumerable<Assignment> GetAssignmentsWithHelpRequestsByStudent(Student student);
        IEnumerable<Assignment> GetAssignmentsByCourse(Course course);

    }
}