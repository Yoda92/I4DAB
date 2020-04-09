using Assignment2.BottomLayerPersistenceLogic.Repositories;
using Assignment2.TopLayer;
using Assignment2.TopLayer.RepositoryInterfaces;

namespace Assignment2.BottomLayerPersistenceLogic
{
    public class UnitOfWork : IUnitOfWork
    {
        private StudentHelperContext _StudentHelperContext;
        public UnitOfWork(StudentHelperContext context)
        {
            _StudentHelperContext = context;
            Assignments = new AssignmentRepository(_StudentHelperContext);
            Courses = new CourseRepository(_StudentHelperContext);
            Exercises = new ExerciseRepository(_StudentHelperContext);
            Students = new StudentRepository(_StudentHelperContext);
            Teachers = new TeacherRepository(_StudentHelperContext);
            HelpRequests = new HelpRequestRepository(_StudentHelperContext);
        }
        public IAssignmentRepository Assignments { get; }
        public ICourseRepository Courses { get; }
        public IExerciseRepository Exercises { get; }
        public IStudentRepository Students { get; }
        public ITeacherRepository Teachers { get; }
        public IHelpRequestRepository HelpRequests { get; }

        public int Complete()
        {
            return _StudentHelperContext.SaveChanges();
        }

        public void Dispose()
        {
            _StudentHelperContext.Dispose();
        }
    }
}