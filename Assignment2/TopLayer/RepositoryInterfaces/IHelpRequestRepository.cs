using System.Collections;
using System.Collections.Generic;
using Assignment2.TopLayer.Domain;

namespace Assignment2.TopLayer.RepositoryInterfaces
{
    public class TeacherHelpRequestExercise
    {
        public string StudentAUID { get; set; }
        public int Lecture { get; set; }
        public int Number { get; set; }
        public string HelpWhere { get; set; }
        public string Name { get; set; }
    }
    public class TeacherHelpRequestAssignment
    {
        public string StudentAUID { get; set; }
        public string Name { get; set; }
        public int AssignmentId { get; set; }
    }
    public interface IHelpRequestRepository
    {
        public IEnumerable<StudentAssignment> GetStudentAssignments(string studentId);
        public IEnumerable<StudentExercise> GetStudentExercises(string studentId);
        public IEnumerable<TeacherHelpRequestExercise> GetTeacherExercises(string teacherId, int courseId);
        public IEnumerable<TeacherHelpRequestAssignment> GetTeacherAssignments(string teacherId, int courseId);
    }
}
