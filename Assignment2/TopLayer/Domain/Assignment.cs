using System.Collections.Generic;


namespace Assignment2.TopLayer.Domain
{
    public class Assignment
    {
        public uint ID { get; set; }
        public string Description { get; set; }

     
        public Teacher Teacher { get; set; }
        public List<StudentAssignment> StudentAssignment { get; set; }

    }
}