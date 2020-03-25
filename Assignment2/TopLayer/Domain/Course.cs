using System.Collections.Generic;

namespace Assignment2.TopLayer.Domain
{
    public class Course
    {
        public uint ID { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        public uint AssignmentID { get; set; }
        public List<Assignment> Assignments { get; set; }

        public List<StudentCourse> StudentsAttending { get; set; } 
        

        public List<TeacherCourse> TeachersResponsible { get; set; } 
    }
}