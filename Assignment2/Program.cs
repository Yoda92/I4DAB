using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Assignment2.BottomLayerPersistenceLogic;
using Assignment2.BottomLayerPersistenceLogic.Repositories;
using Assignment2.TopLayer.Domain;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            while (true)
            {
                InitMessage();
                Console.WriteLine("Please enter a command:");
                input = Console.ReadLine();
                switch (input)
                {
                    case "CreateCourse":
                        {
                            CreateCourse();
                            break;
                        }
                    case "CreateStudent":
                        {
                            CreateStudent();
                            break;
                        }
                    case "GetHelpRequestsStudent":
                        {
                            Console.WriteLine("Enter a students AUID");
                            GetOpenHelpRequests(System.Console.ReadLine());
                            break;
                        }
                    case "GetHelpRequestsTeacher":
                        {
                            Console.WriteLine("Enter teachers AUID");
                            break;
                        }
                    case "CreateExercise":
                        {
                            CreateExercise();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Illegal input! Try again.");
                            break;
                        }
                }
            }
        }

        static void InitMessage()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine("||                       HELP REQUEST DATABASE PROGRAM 3000                        ||");
            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine("|| List of commands          || Description                                        ||");
            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine("|| CreateCourse              || Creates a new course.                              ||");
            Console.WriteLine("|| CreateStudent             || Creates a new student                              ||");
            Console.WriteLine("|| CreateTeacher             || Creates a new teacher.                             ||");
            Console.WriteLine("|| CreateAssignment          || Creates a new assignment.                          ||");
            Console.WriteLine("|| CreateExercise            || Creates a new exercise.                            ||");
            Console.WriteLine("|| CreateHelpRequest         || Creates a new help request.                        ||");
            Console.WriteLine("|| GetHelpRequestsStudent    || Shows all open help request given a student.       ||");
            Console.WriteLine("|| GetHelpRequestsTeacher    || Shows all open help request given a teacher.       ||");
            Console.WriteLine("|| GetStatistics             || Shows statistics for all help requests             ||");
            Console.WriteLine("-------------------------------------------------------------------------------------");
        }

        static void CreateCourse()
        {
            Course newCourse = new Course();
            Console.WriteLine("Please enter the name of the new course:");
            newCourse.Name = Console.ReadLine();
            using (var _UnitOfWork = new UnitOfWork(new StudentHelperContext()))
            {
                _UnitOfWork.Courses.Add(newCourse);
                _UnitOfWork.Complete();
            }
            Console.WriteLine("Course created.");
        }

        static void CreateStudent()
        {
            Student newStudent = new Student();
            Console.WriteLine("Please enter the name of the new student:");
            newStudent.Name = Console.ReadLine();
            Console.WriteLine("Please enter the AUID of the new student:");
            newStudent.AUID = Console.ReadLine();
            using (var _UnitOfWork = new UnitOfWork(new StudentHelperContext()))
            {
                _UnitOfWork.Students.Add(newStudent);
                _UnitOfWork.Complete();
            }
            Console.WriteLine("Student created.");
        }

        static void CreateTeacher()
        {
            Teacher newTeacher = new Teacher();
            Console.WriteLine("Please enter the name of the new teacher:");
            newTeacher.Name = Console.ReadLine();
            Console.WriteLine("Please enter the AUID of the new teacher:");
            newTeacher.AUID = Console.ReadLine();
            using (var _UnitOfWork = new UnitOfWork(new StudentHelperContext()))
            {
                _UnitOfWork.Teachers.Add(newTeacher);
                _UnitOfWork.Complete();
            }
        }

        static void CreateAssignment()
        {

        }

        static void CreateExercise()
        {
            Exercise newExercise = new Exercise();
            Console.WriteLine("Please enter lecture number. This is half of a primary key");
            newExercise.Lecture = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please enter exercise number. This is the other half of the primary key");
            newExercise.Number = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please specify where help can be found");
            newExercise.HelpWhere = Console.ReadLine();
            using (var _UnitOfWork = new UnitOfWork(new StudentHelperContext()))
            {
                foreach (Teacher t in _UnitOfWork.Teachers.GetAll())
                {
                    Console.WriteLine($"Name: {t.Name}, AUID: {t.AUID}");
                }
            }
            Console.WriteLine("Please specify the AUID of the teacher who is resposible for this exercise");
            newExercise.TeacherAUID = Console.ReadLine();
            using (var _UnitOfWork = new UnitOfWork(new StudentHelperContext()))
            {
                _UnitOfWork.Exercises.Add(newExercise);
                _UnitOfWork.Complete();
            }
        }

        static void CreateHelpRequest()
        {

        }

        static void GetOpenHelpRequests(string teacherId, string courseId)
        {

        }

        static void GetOpenHelpRequests(string studentId)
        {
            using (var _UnitOfWork = new UnitOfWork(new StudentHelperContext()))
            {
                System.Console.WriteLine("Current help requests in assignments:");
                foreach (StudentAssignment element in _UnitOfWork.HelpRequests.GetStudentAssignments(studentId))
                {
                    System.Console.WriteLine("Assignment ID: " + element.AssignmentID);
                }
                System.Console.WriteLine("Current help requests in exercises:");
                foreach (StudentExercise element in _UnitOfWork.HelpRequests.GetStudentExercises(studentId))
                {
                    System.Console.WriteLine("Exercise lecture,number: " + element.ExerciseLecture + "," + element.ExerciseNumber);
                }
                _UnitOfWork.Complete();
            }
        }

        static void GetStatistics()
        {

        }
    }
}
