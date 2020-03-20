using DAB_assignment_2.TopLayer.RepositoryInterfaces;
using System;

namespace DAB_assignment_2.TopLayer
{
    public interface IUnitOfWork : IDisposable
    {
        IAssignmentRepository Assignments {get; }
        ICourseRepository Courses { get; }
        IExerciseRepository Exercises { get; }
        ILectureRepository Lectures { get; }
        IStudentRepository Students { get; }
        ITeacherRepository Teachers { get; }

        int Complete();
    }
}