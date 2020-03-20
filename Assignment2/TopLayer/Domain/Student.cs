using System.Collections.Generic;

namespace DAB_assignment_2.TopLayer.Domain
{
    public class Student
    {
        public string AUID { get; set; }
        public string Name { get; set; }
        public uint CurrentSemester { get; set; }


        public List<StudentCourse> StudentCourses { get; set; }
        public List<StudentExercise> StudentExercise { get; set; }
        public List<StudentAssignment> StudentAssignment { get; set; }
    }
}