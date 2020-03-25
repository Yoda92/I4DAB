using System.Collections.Generic;

namespace Assignment2.TopLayer.Domain
{
    public class Student
    {
        public string AUID { get; set; }
        public string Name { get; set; }
        

        public List<StudentCourse> StudentCourses { get; set; }
        public List<Exercise> Exercises { get; set; }
        public List<StudentAssignment> StudentAssignments { get; set; }
    }
}