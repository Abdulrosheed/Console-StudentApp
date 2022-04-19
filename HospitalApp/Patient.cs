using System;
namespace HospitalApp
{
    public class Patient
    {
        private static int NumberOfPateints;
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string PhoneNumber { get; set; }
        private string Email { get; set; }
        private string Gender { get; set; }
        private DateTime DateOfRegistration { get; set; }
        private int Age { get; set; }
        private string PatientNumber { get; set; }


        public Patient(string firstName, string lastName, string phoneNumber, string email, string gender, int age, DateTime dateOfRegistration)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.DateOfRegistration = dateOfRegistration;
            this.Age = age;
            this.PatientNumber = GeneratePatientNumber();
            this.Gender = gender;
        }
        private Patient(string patientNumber, string firstName, string lastName, string phoneNumber, string email, string gender, int age, DateTime dateOfRegistration)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.DateOfRegistration = dateOfRegistration;
            this.Age = age;
            this.PatientNumber = GeneratePatientNumber();
            this.Gender = gender;
            this.PatientNumber = patientNumber;
        }

        public override string ToString()
        {
            return $"{PatientNumber}\t{FirstName}\t{LastName}\t{PhoneNumber}\t{Email}\t{Gender}\t{Age}\t{DateOfRegistration}";
        }

        public string GetName()
        {
            return $"{FirstName}\t{LastName}";
        }

        public string GetPatientNumber()
        {
            return PatientNumber;
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
                        Console.WriteLine("Enter your new first Name? ");
                        bool result = int.TryParse(Console.ReadLine(), out int age);
                        if (!result)
                        {
                            Console.WriteLine("Invalid Age");
                        }
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

        private string GeneratePatientNumber()
        {
            string initials = $"{FirstName[0]}{LastName[0]}".ToUpper();
            string date = DateOfRegistration.ToShortDateString().Replace("/", "").Trim();
            int number = ++NumberOfPateints;
            return $"{number}/{initials}/{date}";
        }

        public static Patient Parse(string line)
        {
            string[] content = line.Split("\t");
            return new Patient(content[0], content[1], content[2], content[3], content[4], content[5],int.Parse(content[6]), DateTime.Parse(content[7]));
        }


    }
}