using Assignment2.TopLayer.RepositoryInterfaces;
using Assignment2.TopLayer.Domain;
using System.Collections.Generic;

namespace Assignment2.BottomLayerPersistenceLogic.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(StudentHelperContext context) : base(context)
        {
        }
    }
}