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
                    case "CreateTeacher":
                        {
                            CreateTeacher();
                            break;
                        }
                    case "CreateAssignment":
                        {
                            CreateAssignment();
                            break;
                        }
                    case "CreateExercise":
                        {
                            CreateExercise();
                            break;
                        }
                    case "CreateHelpRequestAssignment":
                        {
                            CreateHelpRequestAssignment();
                            break;
                        }
                    case "CreateHelpRequestExercise":
                    {
                        CreateHelpRequestExercise();
                        break;
                    }
                    case "GetHelpRequestsStudent":
                        {
                            GetOpenHelpRequestsStudent();
                            break;
                        }
                    case "GetHelpRequestsTeacher":
                        {
                            GetOpenHelpRequestsTeacher();
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
            Console.WriteLine("||                       HELP REQUEST DATABASE PROGRAM 3000                         ||");
            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine("|| List of commands           || Description                                        ||");
            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine("|| CreateCourse               || Creates a new course.                              ||");
            Console.WriteLine("|| CreateStudent              || Creates a new student                              ||");
            Console.WriteLine("|| CreateTeacher              || Creates a new teacher.                             ||");
            Console.WriteLine("|| CreateAssignment           || Creates a new assignment.                          ||");
            Console.WriteLine("|| CreateExercise             || Creates a new exercise.                            ||");
            Console.WriteLine("|| CreateHelpRequestAssignment|| Creates a new assignment help request.             ||");
            Console.WriteLine("|| CreateHelpRequestExercise  || Creates a new exercise help request.               ||");
            Console.WriteLine("|| GetHelpRequestsStudent     || Shows all open help request given a student.       ||");
            Console.WriteLine("|| GetHelpRequestsTeacher     || Shows all open help request given a teacher.       ||");
            Console.WriteLine("|| GetStatistics              || Shows statistics for all help requests             ||");
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
            Assignment newAssignment = new Assignment();
            Console.WriteLine("Below you see the names and IDs of the available courses.");
            using (UnitOfWork _unitOfWork = new UnitOfWork(new StudentHelperContext()))
            {
                foreach (Course course in _unitOfWork.Courses.GetAll())
                {
                    Console.WriteLine($"Course name: {course.Name}, Course ID: {course.CourseID}");
                }
            }
            Console.WriteLine("Please enter the course ID corresponding to this exercise:");
            newAssignment.CourseID = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the integer ID of the new assignment:");
            newAssignment.AssignmentID = int.Parse(Console.ReadLine());

            Console.WriteLine("Below you see a list of registered teachers:");
            using (var _UnitOfWork = new UnitOfWork(new StudentHelperContext()))
            {
                foreach (Teacher t in _UnitOfWork.Teachers.GetAll())
                {
                    Console.WriteLine($"Name: {t.Name}, AUID: {t.AUID}");
                }
            }
            Console.WriteLine("Please enter the AUID of the teacher responsible for this assignment:");
            newAssignment.TeacherAUID = Console.ReadLine();

            using (var _UnitOfWork = new UnitOfWork(new StudentHelperContext()))
            {
                _UnitOfWork.Assignments.Add(newAssignment);
                _UnitOfWork.Complete();
            }
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
                foreach (Course c in _UnitOfWork.Courses.GetAll())
                {
                    Console.WriteLine($"Name: {c.Name}, CourseID: {c.CourseID}");
                }
            }
            Console.WriteLine("Please Specify which course this exercise is associated with");
            newExercise.CourseID = Int32.Parse(Console.ReadLine());
            using (var _UnitOfWork = new UnitOfWork(new StudentHelperContext()))
            {
                _UnitOfWork.Exercises.Add(newExercise);
                _UnitOfWork.Complete();
            }
        }

        static void CreateHelpRequestAssignment()
        {
            StudentAssignment newStudentAssignment = new StudentAssignment();
            using (var _UnitOfWork = new UnitOfWork(new StudentHelperContext()))
            {
                Console.WriteLine("Current available student ID's:");
                foreach (Student element in _UnitOfWork.Students.GetAll())
                {
                    Console.WriteLine(element.AUID);
                }
            }
            Console.WriteLine("Enter students AUID");
            newStudentAssignment.StudentAUID = System.Console.ReadLine();

            using (var _UnitOfWork = new UnitOfWork(new StudentHelperContext()))
            {
                Console.WriteLine("Current assignment ID's:");
                foreach (Assignment element in _UnitOfWork.Assignments.GetAll())
                {
                    Console.WriteLine(element.AssignmentID);
                }
            }
            Console.WriteLine("Enter assignment ID");
            newStudentAssignment.AssignmentID = int.Parse(System.Console.ReadLine());

            using (var _UnitOfWork = new UnitOfWork(new StudentHelperContext()))
            {
                _UnitOfWork.HelpRequests.AddHelpRequestAssignment(newStudentAssignment);
                _UnitOfWork.Complete();
            }
        }

        static void CreateHelpRequestExercise()
        {
            StudentExercise newStudentExercise = new StudentExercise();
            using (var _UnitOfWork = new UnitOfWork(new StudentHelperContext()))
            {
                Console.WriteLine("Current available student ID's:");
                foreach (Student element in _UnitOfWork.Students.GetAll())
                {
                    Console.WriteLine(element.AUID);
                }
            }
            Console.WriteLine("Enter students AUID");
            newStudentExercise.StudentAUID = System.Console.ReadLine();

            using (var _UnitOfWork = new UnitOfWork(new StudentHelperContext()))
            {
                Console.WriteLine("Current exercise numbers, lectures:");
                foreach (Exercise element in _UnitOfWork.Exercises.GetAll())
                {
                    Console.WriteLine(element.Number + ", " + element.Lecture);
                }
            }
            Console.WriteLine("Enter exercise number");
            newStudentExercise.ExerciseNumber = int.Parse(System.Console.ReadLine());
            Console.WriteLine("Enter lecture");
            newStudentExercise.ExerciseLecture = int.Parse(System.Console.ReadLine());

            using (var _UnitOfWork = new UnitOfWork(new StudentHelperContext()))
            {
                _UnitOfWork.HelpRequests.AddHelpRequestExercise(newStudentExercise);
                _UnitOfWork.Complete();
            }
        }

        static void GetOpenHelpRequestsTeacher()
        {
            using (var _UnitOfWork = new UnitOfWork(new StudentHelperContext()))
            {
                Console.WriteLine("Current available teacher ID's:");
                foreach (Teacher element in _UnitOfWork.Teachers.GetAll())
                {
                    Console.WriteLine(element.AUID);
                }
            }
            Console.WriteLine("Enter teachers AUID");
            string teacherId = System.Console.ReadLine();

            using (var _UnitOfWork = new UnitOfWork(new StudentHelperContext()))
            {
                Console.WriteLine("Current available course ID's:");
                foreach (Course element in _UnitOfWork.Courses.GetAll())
                {
                    Console.WriteLine(element.CourseID);
                }
            }
            Console.WriteLine("Enter course ID");
            string courseId = System.Console.ReadLine();

            Console.WriteLine("Open exercise help requests:");
            using (var _UnitOfWork = new UnitOfWork(new StudentHelperContext()))
            {
                foreach (var h in _UnitOfWork.HelpRequests.GetTeacherExercises(teacherId, Int32.Parse(courseId)))
                {
                    Console.WriteLine($"StudentName: {h.Name}, StudentAUID: {h.StudentAUID}, Exercise {h.Lecture}-{h.Number}, HelpWhere: {h.HelpWhere}");
                }
            }

            Console.WriteLine("Open assignment help requests:");
            using (var _UnitOfWork = new UnitOfWork(new StudentHelperContext()))
            {
                foreach (var h in _UnitOfWork.HelpRequests.GetTeacherAssignments(teacherId, Int32.Parse(courseId)))
                {
                    Console.WriteLine($"StudentName: {h.Name}, StudentAUID: {h.StudentAUID}, AssignmentID: {h.AssignmentId}");
                }
            }
        }

        static void GetOpenHelpRequestsStudent()
        {
            using (var _UnitOfWork = new UnitOfWork(new StudentHelperContext()))
            {
                Console.WriteLine("Current available student ID's:");
                foreach (Student element in _UnitOfWork.Students.GetAll())
                {
                    Console.WriteLine(element.AUID);
                }
            }
            Console.WriteLine("Enter students AUID");
            string studentId = System.Console.ReadLine();

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
