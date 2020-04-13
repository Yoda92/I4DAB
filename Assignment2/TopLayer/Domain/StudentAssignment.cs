namespace Assignment2.TopLayer.Domain
{
    public class StudentAssignment
    {
        public bool IsOpen { get; set; }
        public string StudentAUID { get; set; }
        public Student Student { get; set; }
        public int AssignmentID { get; set; }
        public Assignment Assignment { get; set; }
    }
}