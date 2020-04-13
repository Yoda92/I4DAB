using Assignment2.BottomLayerPersistenceLogic.Repositories;
using Assignment2.TopLayer;
using Assignment2.TopLayer.Domain;
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
            StudentExercises = new StudentExerciseRepository(_StudentHelperContext);
            StudentAssignments = new StudentAssignmentRepository(_StudentHelperContext);
        }
        public IStudentAssignmentRepository StudentAssignments { get; }
        public IAssignmentRepository Assignments { get; }
        public ICourseRepository Courses { get; }
        public IExerciseRepository Exercises { get; }
        public IStudentRepository Students { get; }
        public ITeacherRepository Teachers { get; }
        public IHelpRequestRepository HelpRequests { get; }
        public IStudentExerciseRepository StudentExercises { get; }

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