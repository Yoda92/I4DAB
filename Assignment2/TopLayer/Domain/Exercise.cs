using System.Collections.Generic;

namespace Assignment2.TopLayer.Domain
{
    public class Exercise
    {
        public string Description { get; set; }
        public uint Lecture { get; set; }
        public uint Number { get; set; }
        public string HelpWhere { get; set; }
        public Student Student { get; set; }

        public Teacher Teacher { get; set; }
    }
}