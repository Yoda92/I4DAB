using System.Collections.Generic;


namespace DAB_assignment_2.TopLayer.Domain
{
    public class Assignment
    {
        public uint ID { get; set; }
        public string Description { get; set; }

        public uint CourseID { get; set; }
        public Course Course { get; set; }

        public List<StudentAssignment> StudentAssignment { get; set; }

    }
}