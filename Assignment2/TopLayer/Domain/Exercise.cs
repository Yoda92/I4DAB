using System.Collections.Generic;

namespace DAB_assignment_2.TopLayer.Domain
{
    public class Exercise
    {
        public uint ID { get; set; }
        public string Description { get; set; }

        public uint LectureID { get; set; }
        public Lecture Lecture { get; set; }

        public List<StudentExercise> StudentExercise { get; set; }

    }
}