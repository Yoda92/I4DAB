namespace Assignment2.TopLayer.Domain
{
    public class StudentCourse
    {
        public string StudentAUID { get; set; }
        public Student Student { get; set; }

        public uint CourseID { get; set; }
        public Course Course { get; set; }
    }
}