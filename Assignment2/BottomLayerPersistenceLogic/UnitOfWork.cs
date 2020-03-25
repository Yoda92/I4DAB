using Assignment2.TopLayer;
using Assignment2.TopLayer.RepositoryInterfaces;

namespace Assignment2.BottomLayerPersistenceLogic
{
    public class UnitOfWork : IUnitOfWork
    {
        private StudentHelperContext _studentHelperContext = new StudentHelperContext();

        public IAssignmentRepository Assignments => throw new System.NotImplementedException();

        public ICourseRepository Courses => throw new System.NotImplementedException();

        public IExerciseRepository Exercises => throw new System.NotImplementedException();

        public ILectureRepository Lectures => throw new System.NotImplementedException();

        public IStudentRepository Students => throw new System.NotImplementedException();

        public ITeacherRepository Teachers => throw new System.NotImplementedException();

        public int Complete()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}