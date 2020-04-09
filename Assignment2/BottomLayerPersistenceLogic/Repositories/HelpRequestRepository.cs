using System.Collections;
using System.Collections.Generic;
using Assignment2.TopLayer.RepositoryInterfaces;
using Assignment2.TopLayer.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Assignment2.BottomLayerPersistenceLogic.Repositories
{
    class HelpRequestRepository: IHelpRequestRepository
    {
        public StudentHelperContext Context { get; set; }

        public HelpRequestRepository(StudentHelperContext context)
        {
            Context = context;
        }

        public IEnumerable<StudentAssignment> GetStudentAssignments(string studentId)
        {
            return Context.StudentAssignments.Where(s => s.StudentAUID == studentId).ToList();
            // throw new System.NotImplementedException();
        }
    }
}
