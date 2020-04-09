using System.Collections.Generic;
using Assignment2.TopLayer.Domain;

namespace Assignment2.TopLayer.RepositoryInterfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        // IEnumerable<Course> GetCoursesByStudent(Student student);
        // IEnumerable<Course> GetCoursesByTeacher(Teacher teacher);
    }
}