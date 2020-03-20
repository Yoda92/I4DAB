namespace Assignment2.TopLayer.Domain
{
    public class StudentAssignment
    {
        public uint StudentAUID { get; set; }
        public Student Student { get; set; }

        public uint AssignmentID { get; set; }
        public Assignment Assignment { get; set; }
    }
}