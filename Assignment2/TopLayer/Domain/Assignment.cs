using System.Collections.Generic;


namespace Assignment2.TopLayer.Domain
{
    public class Assignment
    {
        public int AssignmentID { get; set; }
        public string TeacherAUID { get; set; }
        public Teacher Teacher { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public List<StudentAssignment> StudentAssignment { get; set; }
    }
}