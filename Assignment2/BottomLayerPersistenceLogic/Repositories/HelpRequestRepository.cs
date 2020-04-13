﻿using System.Collections;
using System.Collections.Generic;
using Assignment2.TopLayer.RepositoryInterfaces;
using Assignment2.TopLayer.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;

namespace Assignment2.BottomLayerPersistenceLogic.Repositories
{
    class HelpRequestRepository : IHelpRequestRepository
    {
        public StudentHelperContext Context { get; set; }

        public HelpRequestRepository(StudentHelperContext context)
        {
            Context = context;
        }

        public void CloseHelpRequestAssignment(StudentAssignment studentAssignment)
        {
            var entity = Context.StudentAssignments.First(item =>
                item.StudentAUID == studentAssignment.StudentAUID &&
                item.AssignmentID == studentAssignment.AssignmentID);
            entity.IsOpen = false;
            Context.StudentAssignments.Update(entity);
        }

        public void CloseHelpRequestExercise(StudentExercise studentExercise)
        {
            var entity = Context.StudentExercises.First(item =>
                item.StudentAUID == studentExercise.StudentAUID &&
                item.ExerciseLecture == studentExercise.ExerciseLecture &&
                item.ExerciseNumber == studentExercise.ExerciseNumber);
            entity.IsOpen = false;
            Context.StudentExercises.Update(entity);
        }

        public void AddHelpRequestAssignment(StudentAssignment studentAssignment)
        {
            Context.Set<StudentAssignment>().Add(studentAssignment);
        }

        public void AddHelpRequestExercise(StudentExercise studentExercise)
        {
            Context.Set<StudentExercise>().Add(studentExercise);
        }

        public IEnumerable<StudentAssignment> GetStudentAssignments(string studentId)
        {
            return Context.StudentAssignments.Where(s => s.StudentAUID == studentId && s.IsOpen == true).ToList();
        }

        public IEnumerable<StudentExercise> GetStudentExercises(string studentId)
        {
            return Context.StudentExercises.Where(s => s.StudentAUID == studentId && s.IsOpen == true).ToList();
        }

        public IEnumerable<TeacherHelpRequestAssignment> GetTeacherAssignments(string teacherId, int courseId)
        {
            return Context.Assignments.Where(a => (a.TeacherAUID == teacherId && a.CourseID == courseId)).Join(
                    Context.StudentAssignments,
                    a => new { a.AssignmentID },
                    sa => new { sa.AssignmentID },
                    (a, sa) => new
                    {
                        sa.IsOpen,
                        sa.StudentAUID,
                        sa.AssignmentID
                    }
                ).Where(hr => hr.IsOpen).Join(
                    Context.Students,
                    hr => hr.StudentAUID,
                    s => s.AUID,
                    (hr, s) => new TeacherHelpRequestAssignment
                    {
                        StudentAUID = hr.StudentAUID,
                        Name = s.Name,
                        AssignmentId = hr.AssignmentID
                    }
                )
                .ToList();
        }

        public IEnumerable<TeacherHelpRequestExercise> GetTeacherExercises(string teacherId, int courseId)
        {
            return Context.Exercises.Where(e => (e.TeacherAUID == teacherId && e.CourseID == courseId)).Join(
                Context.StudentExercises,
                e => new { e.Lecture, e.Number, e.CourseID },
                se => new { Lecture = se.ExerciseLecture, Number = se.ExerciseNumber, CourseID = se.CourseId },
                (e, se) => new
                {
                    se.IsOpen,
                    se.StudentAUID,
                    e.Course,
                    e.Lecture,
                    e.Number,
                    e.HelpWhere
                }
            ).Where(hr => hr.IsOpen).Join(
                Context.Students,
                hr => hr.StudentAUID,
                s => s.AUID,
                (hr, s) => new TeacherHelpRequestExercise
                {
                    StudentAUID = hr.StudentAUID,
                    Lecture = hr.Lecture,
                    Number = hr.Number,
                    HelpWhere = hr.HelpWhere,
                    Name = s.Name
                }
            )
            .ToList();
        }
    }
}
