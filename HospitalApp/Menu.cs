using System.Net.Mime;
using System;
namespace HospitalApp
{
    public class Menu
    {
        public Menu()
        {
            _patientManager = new PatientManager("C:\\Users\\Abdulrazaq Olanite O\\Desktop\\Personal\\FileApp\\HospitalApp\\patient.txt");
        }
        readonly PatientManager _patientManager;
        bool flag;
        public void StartApp()
        {
            do
            {
                Console.WriteLine("Welcome to Aduke's Hospitol, What do you what to do today? ");
                MenuOptions();
                var option = HandleSelections(Console.ReadLine());
                handleMenuOption(option);
            } while (flag);
            { Console.WriteLine("Thank you for using our application"); };
        }

        public void MenuOptions()
        {
            Console.WriteLine("Enter 1 for Patient");
            Console.WriteLine("Enter 2 for Medical records");
            Console.WriteLine("Enter 0 to stop the application");
        }

        public void handleMenuOption(int option)
        {
            int action;
            switch (option)
            {
                case 1:
                    PatinetSubMenuOption();
                    action = HandleSelections(Console.ReadLine());
                    HandlePatientSubMenuOption(action);
                    break;
                case 2:
                    PatinetSubMenuOption();
                    action = HandleSelections(Console.ReadLine());
                    HandleMedicalRecordSubMenuOption(action);
                    break;
                case 0:
                    flag = false;
                    break;
            }
        }

        public void PatinetSubMenuOption()
        {
            Console.WriteLine("Enter 1 To add new Patinet");
            Console.WriteLine("Enter 2 to update a Patinet");
            Console.WriteLine("Enter 3 to List Patients");
            Console.WriteLine("Enter 4 to Find Patient");
            Console.WriteLine("Enter 0 to go back");
        }

        public void HandlePatientSubMenuOption(int option)
        {
            int action;
            switch (option)
            {
                case 1:
                    _patientManager.Add();
                    PatinetSubMenuOption();
                    action = HandleSelections(Console.ReadLine());
                    HandlePatientSubMenuOption(action);
                    break;
                case 2:
                    _patientManager.Update();
                    PatinetSubMenuOption();
                    action = HandleSelections(Console.ReadLine());
                    HandlePatientSubMenuOption(action);
                    break;
                case 3:
                    _patientManager.List();
                    PatinetSubMenuOption();
                    action = HandleSelections(Console.ReadLine());
                    HandlePatientSubMenuOption(action);
                    break;
                case 4:
                    _patientManager.Find();
                    PatinetSubMenuOption();
                    action = HandleSelections(Console.ReadLine());
                    HandlePatientSubMenuOption(action);
                    break;
                case 0:
                    MenuOptions();
                    action = HandleSelections(Console.ReadLine());
                    handleMenuOption(action);
                    break;
            }
        }

        public void HandleMedicalRecordSubMenuOption(int action)
        {

        }

        public int HandleSelections(string selcetion)
        {
            bool result = int.TryParse(selcetion, out int action);
            while (result == false)
            {
                Console.WriteLine("Try again!");
                result = int.TryParse(Console.ReadLine(), out action);
            }
            return action;
        }
    }
}