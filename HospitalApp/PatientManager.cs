using System;
using System.Collections.Generic;
namespace HospitalApp
{
    public class PatientManager
    {
        Dictionary<string, Patient> Patients { get; set; }
        string FileName { get; set; }

        readonly FileManager FileManager;

        public PatientManager(string fileName)
        {
            FileName = fileName;
            FileManager = new FileManager(FileName);
            Patients = new();
            LoadPatientRecord();
        }

        private void LoadPatientRecord()
        {
            var result = FileManager.ReadFile().GetEnumerator();
            while (result.MoveNext())
            {
                var patient = Patient.Parse(result.Current);
                Patients[patient.GetPatientNumber()] = patient;
            }
        }

        public void Add()
        {
            Console.WriteLine("Enter your First Name: ");
            var firstName = Console.ReadLine();
            Console.WriteLine("Enter your Last Name: ");
            var lastName = Console.ReadLine();
            Console.WriteLine("Enter your Phone Number: ");
            var phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter your Email");
            var email = Console.ReadLine();
            Console.WriteLine("Enter your Age: ");
            var age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Gender: ");
            var gender = Console.ReadLine();
            var patient = new Patient(firstName, lastName, phoneNumber, email, gender, age, DateTime.Now);
            Save(patient);
        }

        public void List()
        {
            foreach (Patient patient in Patients.Values)
            {
                Console.WriteLine(patient.ToString());
            }
        }

        private void Save(Patient patient)
        {
            Patients[patient.GetPatientNumber()] = patient;
            FileManager.WriteToFile(patient.ToString());
        }

        public void Update()
        {
            Console.WriteLine("Enter patient's number");
            var patient = Patients[Console.ReadLine()];
            patient.UpdateInfo();
            Refresh();
        }

        private void Refresh()
        {
            foreach (Patient patient in Patients.Values)
            {
                FileManager.RefreshFile(patient.ToString());
            }
        }

        public void Find()
        {
            Console.WriteLine("Enter patient's number");
            Console.WriteLine(Patients[Console.ReadLine()].ToString());
        }
    }
}