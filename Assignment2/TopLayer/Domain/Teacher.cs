using System.Collections.Generic;

namespace Assignment2.TopLayer.Domain
{
    public class Teacher
    {
        public string AUID { get; set; }
        public string Name { get; set; }

        public List<Exercise> Exercises { get; set; }

        public List<Assignment> Assignments { get; set; }


        public List<TeacherCourse> ResponsibleForTheseCourses { get; set; } 
    }
}