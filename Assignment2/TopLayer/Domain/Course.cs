using System.Collections.Generic;

namespace DAB_assignment_2.TopLayer.Domain
{
    public class Course
    {
        public uint ID { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        public uint AssignmentID { get; set; }
        public List<Assignment> Assignments { get; set; }


        public uint LectureID { get; set; }
        public List<Lecture> Lectures { get; set; }


        public List<StudentCourse> StudentsAttending { get; set; } 
        

        public List<TeacherCourse> TeachersResponsible { get; set; } 
    }
}