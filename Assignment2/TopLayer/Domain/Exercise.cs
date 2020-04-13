using System.Collections.Generic;

namespace Assignment2.TopLayer.Domain
{
    public class Exercise
    {
        public int Lecture { get; set; }
        public int Number { get; set; }
        public string HelpWhere { get; set; }
        public List<StudentExercise> StudentExercises { get; set; }
        public string TeacherAUID { get; set; }
        public Teacher Teacher { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
    }
}