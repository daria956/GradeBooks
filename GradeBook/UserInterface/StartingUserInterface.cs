using GradeBook.GradeBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.UserInterface
{
    public static class StartingUserInterface
    {
        public static bool Quit = false;
        public static void CommandLoop()
        {
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
            if (command.StartsWith("create"))
                CreateCommand(command);
            else if (command.StartsWith("help"))
                HelpCommand();
            else if (command.StartsWith("quit"))
                Quit = true;
            else Console.WriteLine($"{command} was not recognized, please try again");

        }

        public static void CreateCommand(string command)
        {
            var parts = command.Split(' ');
            if (parts.Length != 2)
            {
                Console.WriteLine(("Commnad not valid, create requires a name which is only one word"));
                return;
            }
            var name = parts[1];
            BaseGradeBook gradeBook = new BaseGradeBook(name);
            Console.WriteLine($"Create gradebook{name}");
            GradeBookUserInterface.CommandLoop(gradeBook);

        }
        public static void LoadCommand(string command)
        {
            var parts = command.Split(' ');
            if (parts.Length != 2)
            {
                Console.WriteLine("Command not valid, Load requires a name.");
                return;
            }
            var name = parts[1];
            var gradeBook = BaseGradeBook.Load(name);

            if (gradeBook == null)
                return;

            GradeBookUserInterface.CommandLoop(gradeBook);
        }

        public static void HelpCommand()
        {
            Console.WriteLine();
            Console.WriteLine("GradeBook has following commands");
            Console.WriteLine();
            Console.WriteLine("Create 'Name' -> Creates a new grandbook of name 'Name'");
            Console.WriteLine();
            Console.WriteLine("Help -> Display all accepted commands");
            Console.WriteLine();
            Console.WriteLine("Quit -> Exits the application");
            Console.WriteLine();
            Console.WriteLine("Remove -> remove a student from a list");
            Console.WriteLine();
            Console.WriteLine();
        }


    }
}


