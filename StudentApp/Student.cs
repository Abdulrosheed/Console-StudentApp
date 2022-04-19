using System;
namespace StudentApp
{
    public class Student
    {
       public string FirstName { get; private set; }
       public string LastName { get; private set; }
       public string Email { get; private set; }
       public string PhoneNumber { get; private set; }
       public int Age { get; private set; }
        string Gender { get; set; }
        public string RegNumber { get; private set; }
        DateTime DateOfRegistration { get; set; }


        public Student(string firstName, string lastName, string email, string phoneNumner, int age, string gender, int studentCount)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumner;
            Age = age;
            Gender = gender;
            RegNumber = GenerateRegNumber(studentCount);
            DateOfRegistration = DateTime.Now;
        }

        private Student(string firstName, string lastName, string email, string phoneNumber, int age, string gender, string regNumber, DateTime dateOfRegistration)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Age = age;
            Gender = gender;
            RegNumber = regNumber;
            DateOfRegistration = dateOfRegistration;
        }

        private string GenerateRegNumber(int studentCount)
        {
            string initials = $"{FirstName[0]}{LastName[0]}".ToUpper();
            string date = DateOfRegistration.ToShortDateString().Replace("/", "").Trim();
            return $"{studentCount++}/{initials}/{date}";
        }

        public string GetRegistrationNumber()
        {
            return RegNumber;
        }

        public override string ToString()
        {
            return $"{FirstName}\t{LastName}\t{Email}\t{PhoneNumber}\t{Age}\t{Gender}\t{RegNumber}\t{DateOfRegistration}";
        }

        public void UpdateInfo()
        {
            bool update = true;
            while (update)
            {
                Console.WriteLine("What do you want to update? ");
                string option = Console.ReadLine();
                switch (option.Trim().ToLower())
                {
                    case "firstname":
                        Console.WriteLine("Enter your new first Name? ");
                        FirstName = Console.ReadLine();
                        break;
                    case "lastname":
                        Console.WriteLine("Enter your new last Name? ");
                        LastName = Console.ReadLine();
                        break;
                    case "email":
                        Console.WriteLine("Enter your new Email? ");
                        Email = Console.ReadLine();
                        break;
                    case "phonenumber":
                        Console.WriteLine("Enter your new Phone Number? ");
                        PhoneNumber = Console.ReadLine();
                        break;
                    case "age":
                        Console.WriteLine("Enter your new Age? ");
                        Age = int.Parse(Console.ReadLine());                      
                        break;
                    default:
                        Console.WriteLine("Please enter valid input!!");
                        break;
                }
                Console.WriteLine("Do you want to continue to update your information, (Yes/No)");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "no")
                {
                    update = false;
                }
            }
        }


        public static Student ConvertToStudent(string line)
        {
            string[] content = line.Split("\t");
            return new Student(content[0], content[1], content[2], content[3], int.Parse(content[4]), content[5], content[6], DateTime.Parse(content[7]));
        }
    }
}