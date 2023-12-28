using GradeBook.Enums;
using GradeBook.GradeBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace GradeBook.UserInterface
{
    public class GradeBookUserInterface
    {
        public static BaseGradeBook GradeBook { get; set; }
        public static bool Quit = false;

        public static void CommandLoop(BaseGradeBook gradebook)
        {
            GradeBook = gradebook;

            Console.WriteLine("#==============================#");
            Console.WriteLine(GradeBook.Name + " " + GradeBook.GetType().Name);
            Console.WriteLine("#===============================#");

            while (!Quit)
            {
                Console.WriteLine(String.Empty);
                Console.WriteLine(">> What whoul you like to do?");
                var command = Console.ReadLine().ToLower();
                CommandRoute(command);
            }
        }
        public static void CommandRoute(string command)
        {
            if (command == "save")
                SaveCommand();
            else if (command.StartsWith("addgrade"))
                AddGradeCommand(command);
            else if (command.StartsWith("removegrade"))
                RemoveGradeCommand(command);
            else if (command.StartsWith("add"))
                AddStudentCommand(command);
            else if (command.StartsWith("remove"))
                RemoveStudentCommand(command);
            else if (command == "list")
                ListCommand();
            else if (command == "statistics all")
                StatisticsCommand();
            else if (command.StartsWith("statistics"))
                StudentsStatisticsCommand(command);
            else if (command == "help")
                HelpCommand();
            else if (command == "close")
                Quit = true;
            else
                Console.WriteLine("{0} was not recognized, please try again.", command);
        }

        public static void SaveCommand()
        {
            GradeBook.Save();
            Console.WriteLine("{0} has been saved.", GradeBook.Name);
        }

        //public static void ShowGradesCommand(string command)
        //{
        //    var parts = command.Split(' ');
        //    if (parts.Length != 2)
        //    {
        //        Console.WriteLine("Command is not valid, shawgrades required a name");
        //        return;
        //    }
        //    var name = parts[1];
        //    GradeBook.ShowGrades(name);

    
    public static void RemoveStudentCommand(string command)
        {
            var parts = command.Split(" ");
            if (parts.Length !=2)
            {
                Console.WriteLine($"Command not valid, remove a reqire name!");
                return;

            }
            var name = parts[1];
            GradeBook.RemoveStudent(name);
            Console.WriteLine($"Remove {name} from the gradebook!");
        }
      
        public static void AddGradeCommand(string command)
        {
            var parts = command.Split(' ');
            if (parts.Length != 3)
            {
                Console.WriteLine("Command not valid");
                return;
            }
            var name = parts[1];
            var score = Double.Parse(parts[2]);
            GradeBook.AddGrade(name, score);
        }
        public static void RemoveGradeCommand(string command)
        {

            var parts = command.Split(' ');
            if (parts.Length !=3)
            {
                Console.WriteLine("Command not valid, RemoveGrades require a name and score");
                return;
            }
            var name = parts[1];
            var score = Double.Parse(parts[2]);
            GradeBook.RemoveGrade(name, score);
            Console.WriteLine($"removed a score of{score} for {name}");
        }

        public static void ListCommand()
        {
            GradeBook.ListStudents();
        }



        public static void AddStudentCommand(string command)
        {
            var parts = command.Split(' ');
            if (parts.Length != 4)
            {
                Console.WriteLine("Command not valid, Add requires a name, student type, enrollment type.");
                return;

            }
            var name = parts[1];

            StudentType studentType;
            if (!(Enum.TryParse(parts[2], true, out studentType)))
            {
                Console.WriteLine("{0} is not a valid student type, try again.", parts[2]);
                return;
            }
            EnrollmentType enrollmentType;
            if (!Enum.TryParse(parts[3], true, out enrollmentType))
            {
                Console.WriteLine("{0} is not a valid enrollment type, try again.", parts[3]);
                return;
            }

            var student = new Students(name, studentType, enrollmentType);
          
            GradeBook.AddStudents(student);
            Console.WriteLine($"Student {student.Name} has been added to your gradebook!");
            

        }
        public static void StatisticsCommand()
        {
            GradeBook.CalculateStatistics();
        }
        public static void StudentsStatisticsCommand (string command)
        {
            var parts = command.Split(" ");
            if (parts.Length != 2)
            {
                Console.WriteLine("Command not valid, requires Name or All");
                return;
            }
            var name = parts[1];
            GradeBook.CalculateStudentStatistics(name);
        }
       
        public static void HelpCommand()
        {
            Console.WriteLine();
            Console.WriteLine("While a gradebook is open, you can use a following commands");
            Console.WriteLine();
            Console.WriteLine("Help -> Display all accepted commands");
            Console.WriteLine();
            Console.WriteLine("Add 'Name', 'Student Type' 'Enrollment Type' -> Adds a new student to the grade book" +
                "with the provided Name, Type and Enrollment Type");
            Console.WriteLine();
            Console.WriteLine("Accepted students' types");
            Console.WriteLine("Standart - student not enrolled in Honor classses or Dual Enrolled");
            Console.WriteLine("Honors - students enrolled in Honors classes and not Dual Enrolled classes");
            Console.WriteLine("DualEnrolled - students who are Dual Enrolled");
            Console.WriteLine();
            Console.WriteLine("Campus => students who are in the same district of school");
            Console.WriteLine("State => students who is legal residence in the outside of school's district " +
                "but is the same state at school");
            Console.WriteLine("National => students who is legal residence is not the same as school" +
                " but is the same country as the school is.");
            Console.WriteLine("International => students who's the legal residence is not in the same country as school");
            Console.WriteLine("Remove 'Name' -> Remove a students from a grade book");
            Console.WriteLine();
            Console.WriteLine("List -> Lists all students");
            Console.WriteLine();
            Console.WriteLine("AddGrade 'Name' 'Score' -> " +
                "Adds new grade to a student matching name od provided score");
            Console.WriteLine();
            Console.WriteLine("RemoveGrade 'Name' 'Score' - Removes a grade to a student with " +
                "the matching name and score");
        }




    }
}



