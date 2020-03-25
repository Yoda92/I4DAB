using Assignment2.TopLayer.RepositoryInterfaces;
using Assignment2.BottomLayerPersistenceLogic;
using System;

namespace Assignment2.TopLayer
{
    public interface IUnitOfWork : IDisposable
    {
        IAssignmentRepository Assignments {get; }
        ICourseRepository Courses { get; }
        IExerciseRepository Exercises { get; }
        IStudentRepository Students { get; }
        ITeacherRepository Teachers { get; }

        int Complete();
    }
}