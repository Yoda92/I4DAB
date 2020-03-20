using DAB_assignment_2.TopLayer;
using DAB_assignment_2.TopLayer.RepositoryInterfaces;

namespace DAB_assignment_2.BottomLayerPersistenceLogic
{
    public class UnitOfWork : IUnitOfWork
    {
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