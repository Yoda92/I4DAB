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
                    case "1":
                    case "CreateCourse":
                        {
                            CreateCourse();
                            break;
                        }
                    case "2":
                    case "CreateStudent":
                        {
                            CreateStudent();
                            break;
                        }
                    case "3":
                    case "CreateTeacher":
                        {
                            CreateTeacher();
                            break;
                        }
                    case "4":
                    case "CreateAssignment":
                        {
                            CreateAssignment();
                            break;
                        }
                    case "5":
                    case "CreateExercise":
                        {
                            CreateExercise();
                            break;
                        }
                    case "6":
                    case "CreateHelpRequestAssignment":
                        {
                            CreateHelpRequestAssignment();
                            break;
                        }
                    case "7":
                    case "CreateHelpRequestExercise":
                        {
                            CreateHelpRequestExercise();
                            break;
                        }
                    case "8":
                    case "GetHelpRequestsStudent":
                        {
                            GetOpenHelpRequestsStudent();
                            break;
                        }
                    case "9":
                    case "GetHelpRequestsTeacher":
                        {
                            GetOpenHelpRequestsTeacher();
                            break;
                        }
                    case "10":
                    case "GetStatistics":
                        {
                            GetStatistics();
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
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("||                       HELP REQUEST DATABASE PROGRAM 3000                              ||");
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("|| ID ||List of commands           || Description                                        ||");
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("|| 1  ||CreateCourse               || Creates a new course.                              ||");
            Console.WriteLine("|| 2  ||CreateStudent              || Creates a new student                              ||");
            Console.WriteLine("|| 3  ||CreateTeacher              || Creates a new teacher.                             ||");
            Console.WriteLine("|| 4  ||CreateAssignment           || Creates a new assignment.                          ||");
            Console.WriteLine("|| 5  ||CreateExercise             || Creates a new exercise.                            ||");
            Console.WriteLine("|| 6  ||CreateHelpRequestAssignment|| Creates a new assignment help request.             ||");
            Console.WriteLine("|| 7  ||CreateHelpRequestExercise  || Creates a new exercise help request.               ||");
            Console.WriteLine("|| 8  ||GetHelpRequestsStudent     || Shows all open help request given a student.       ||");
            Console.WriteLine("|| 9  ||GetHelpRequestsTeacher     || Shows all open help request given a teacher.       ||");
            Console.WriteLine("|| 10 ||GetStatistics              || Shows statistics for all help requests             ||");
            Console.WriteLine("------------------------------------------------------------------------------------------");
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

            Console.WriteLine("Please enter the name of the new assignment:");
            newAssignment.AssignmentName = Console.ReadLine();

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
                foreach (var assignment in _UnitOfWork.HelpRequests.GetStudentAssignments(studentId))
                {
                    System.Console.WriteLine("Assignment ID: " + assignment.AssignmentID + ", Assignment Name: " + assignment.AssignmentName);
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
            using (var _UnitOfWork = new UnitOfWork(new StudentHelperContext()))
            {
                Console.WriteLine("Current available course ID's:");
                foreach (Course course in _UnitOfWork.Courses.GetAll())
                {
                    Console.WriteLine($"CourseName: {course.Name}, CourseId: {course.CourseID}");
                }
            }
            Console.WriteLine("Enter course ID");
            int courseId = Int32.Parse(System.Console.ReadLine());

            int exTotal, exOpen, exClosed, asTotal, asOpen, asClosed;
            using (var _UnitOfWork = new UnitOfWork(new StudentHelperContext()))
            {
                (exTotal, exOpen, exClosed) = _UnitOfWork.HelpRequests.GetExerciseHelpRequestsFromCourse(courseId).Aggregate((0, 0, 0), (statuses, hr) =>
                {
                    var (total, open, closed) = statuses;
                    total++;
                    if (hr.IsOpen) open++;
                    else closed++;
                    return (total, open, closed);
                });

                (asTotal, asOpen, asClosed) = _UnitOfWork.HelpRequests.GetAssignmentHelpRequestsFromCourse(courseId).Aggregate((0, 0, 0), (statuses, hr) =>
                {
                    var (total, open, closed) = statuses;
                    total++;
                    if (hr.IsOpen) open++;
                    else closed++;
                    return (total, open, closed);
                });

            }
            Console.WriteLine("Statistics for exercises");
            Console.WriteLine($"Total: {exTotal}, Open: {exOpen}, Closed: {exClosed}");
            Console.WriteLine("Statistics for assignments");
            Console.WriteLine($"Total: {asTotal}, Open: {asOpen}, Closed: {asClosed}");
        }
    }
}
