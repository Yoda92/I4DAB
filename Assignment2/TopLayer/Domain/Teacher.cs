using System.Collections.Generic;

namespace Assignment2.TopLayer.Domain
{
    public class Teacher
    {
        public string AUID { get; set; }
        public string Name { get; set; }

        //May be assigned to help with either an exercise or an assignment
        public uint? ExerciseID { get; set; } 
        public Exercise Exercise { get; set; }

        public uint? AssignmentID { get; set; }
        public Assignment Assignment { get; set; }

        public uint AuidOfStudentBeingAssisted { get; set; }
        public Student Student { get; set; }

        public List<TeacherCourse> ResponsibleForTheseCourses { get; set; } 
    }
}