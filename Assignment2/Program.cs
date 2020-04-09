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
            InitMessage();
            string input;
            while (true)
            {
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
            // Console.WriteLine("Create Review"); ????
            Console.WriteLine("|| Create Help Request       || Creates a new help request.                        ||");
            Console.WriteLine("|| GetHelpRequestsStudent    || Shows all open help request given a student.       ||");
            Console.WriteLine("|| GetHelpRequestsTeacher    || Creates a new course.                              ||");
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
            }
            Console.WriteLine("Course created.");
        }

        static void CreateStudent()
        {
            Student newStudent = new Student();
            Console.WriteLine("Please enter the name of the new student:");
            newStudent.Name = Console.ReadLine();
            Console.WriteLine("Please enter the AUID of the new student:");
            newStudent.Name = Console.ReadLine();
            using (var _UnitOfWork = new UnitOfWork(new StudentHelperContext()))
            {
                _UnitOfWork.Students.Add(newStudent);
            }
            Console.WriteLine("Student created.");
        }

        static void GetOpenHelpRequests(string teacherId, string courseId)
        {

        }

        static void GetOpenHelpRequests(string studentId)
        {
            using (var _UnitOfWork = new UnitOfWork(new StudentHelperContext()))
            {
                foreach (StudentAssignment element in _UnitOfWork.HelpRequests.GetStudentAssignments(studentId))
                {
                    System.Console.WriteLine("Assignment: " + element.AssignmentID);
                }
            }
        }

        static void GetStatistics()
        {

        }
    }
}
