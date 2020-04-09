namespace Assignment2.TopLayer.Domain
{
    public class TeacherCourse
    {
        public string TeacherAUID { get; set; }
        public Teacher Teacher { get; set; }

        public int CourseID { get; set; }
        public Course Course { get; set; }
        
    }
}