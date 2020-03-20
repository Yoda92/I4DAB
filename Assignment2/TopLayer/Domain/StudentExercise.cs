namespace Assignment2.TopLayer.Domain
{
    public class StudentExercise
    {
        public uint StudentAUID { get; set; }
        public Student Student { get; set; }

        public uint ExerciseID { get; set; }
        public Exercise Exercise { get; set; }
    }
}