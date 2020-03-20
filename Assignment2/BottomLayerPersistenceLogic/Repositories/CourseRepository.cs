using Assignment2.TopLayer.RepositoryInterfaces;
using Assignment2.TopLayer.Domain;
using System.Collections.Generic;

namespace Assignment2.BottomLayerPersistenceLogic.Repositories
{
    public class CourseRepository : Repository<Course> , ICourseRepository
    {
        public CourseRepository(StudentHelperContext context) : base(context)
        {
        }
        
    }
}