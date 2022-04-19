using System.Linq;
using System.Text;
using System.Collections.Generic;
using System;
using System.IO;
namespace FileClass
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            do
            {
                Console.WriteLine("What Do you want to keep in the file");
                string content = Console.ReadLine();
                WriteToFile(".\\file.txt", content);
                flag = CheckIfEnd();
            }
            while (flag);
            Console.WriteLine("Here are the content of your file: ");
            //var contents = ReadFromFile(".\\file.txt");
            foreach (string content in ReadFromFile(".\\file.txt"))
            {
                Console.WriteLine(content);
            }
            Console.WriteLine("Thank you for using our application");
        }

        static void WriteToFile(string path, string content)
        {
            try
            {
                StreamWriter streamWriter = new StreamWriter(path, true);
                streamWriter.WriteLine(content);
                streamWriter.Flush();
                streamWriter.Close();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        static List<string> ReadFromFile(string path)
        {
            List<string> contents = new List<string>();
            StreamReader streamReader = new StreamReader(path);
            while (!streamReader.EndOfStream)
            {
                contents.Add(streamReader.ReadLine());
            }
            streamReader.Close();
            return contents;
        }

        static bool CheckIfEnd()
        {
            Console.WriteLine("Do you want to end the application? (Yes(Y)/No(N))");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "n")
            {
                return false;
            }
            else if (choice.ToLower() == "y")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Application Ending, Bad Input");
                return false;
            }
        }

    }
}
