namespace DAB_assignment_2.TopLayer.Domain
{
    public class StudentCourse
    {
        public uint StudentID { get; set; }
        public Student Student { get; set; }

        public uint CourseID { get; set; }
        public Course Course { get; set; }
    }
}