using System.Collections.Generic;

namespace Assignment2.TopLayer.Domain
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Name { get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<StudentCourse> StudentsAttending { get; set; }
        public List<TeacherCourse> TeachersResponsible { get; set; } 
    }
}