namespace Assignment2.TopLayer.Domain
{
    public class StudentCourse
    {
        public bool IsActive { get; set; }
        public uint Semester { get; set; }

        public string StudentAUID { get; set; }
        public Student Student { get; set; }


        public uint CourseID { get; set; }
        public Course Course { get; set; }
    }
}