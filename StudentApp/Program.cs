using System;

namespace StudentApp
{
    class Program
    {
        delegate void PrintMenuDelegate();
        static StudentManager studentManager = new StudentManager();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome Here!!");
            Run();
        }

        static void Run()
        {
            bool flag;
            PrintMenuDelegate printMenu = new(PrintMenu);
            do
            {
                PrintMenu();
                var option = HandleSelections(Console.ReadLine(), printMenu);
                flag = HandleMenuOption(option);
            }
            while (flag);
            Console.WriteLine("Thank you for using our app");
        }


        static void PrintMenu()
        {
            Console.WriteLine("Enter 1 To Register a student");
            Console.WriteLine("Enter 2 To Update a student Record");
            Console.WriteLine("Enter 3 To List All Students");
            Console.WriteLine("Enter 0 to end");
        }

        static bool HandleMenuOption(int option)
        {
            switch (option)
            {
                case 1:
                    studentManager.Create();
                    return true;
                case 2:
                    studentManager.Update();
                    return true;
                case 3:
                    studentManager.List();
                    return true;
                case 0:
                    return false;
                default:
                    return false;
            }
        }

        static int HandleSelections(string selcetion, PrintMenuDelegate printMenu)
        {
            bool result = int.TryParse(selcetion, out int action);
            while (result == false)
            {
                Console.WriteLine("Try again!");
                printMenu();
                result = int.TryParse(Console.ReadLine(), out action);
            }
            return action;
        }
    }
}
