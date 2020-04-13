using System.Collections.Generic;

namespace Assignment2.TopLayer.Domain
{
    public class StudentExercise
    {
        public bool IsOpen { get; set; }
        public Student Student { get; set; }
        public string StudentAUID { get; set; }
        public Exercise Exercise { get; set; }
        public int ExerciseNumber { get; set; }
        public int ExerciseLecture { get; set; }
        public int CourseId { get; set; }
    }
}