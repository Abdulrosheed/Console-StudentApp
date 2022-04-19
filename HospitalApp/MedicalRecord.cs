using System;
namespace HospitalApp
{
    public class MedicalRecord
    {
        private string Complian { get; set; }
        private string Diagnosis { get; set; }
        private DateTime DateOfAttendence { get; set; }
        private string DoctorsName { get; set; }
        private string Treatmeant { get; set; }
        private Patient Patient { get; set; }
        private string MedNumber { get; set; }

        public MedicalRecord(string complian, string diagnosis, string doctorsName, string treatmeant, Patient patient)
        {
            this.Complian = complian;
            this.Diagnosis = diagnosis;
            this.DateOfAttendence = DateTime.Now;
            this.DoctorsName = doctorsName;
            this.Treatmeant = treatmeant;
            this.Patient = patient;
            this.MedNumber = GenerateMedNumber();
        }

        public string GenerateMedNumber()
        {
            var number = new Guid().ToString().Substring(1, 11).Replace("-", "").Trim().ToLower();
            return $"{number}";
        }

        public override string ToString()
        {
            return $"{Complian}\t{MedNumber}\t{Diagnosis}\t{Treatmeant}\t{DoctorsName}\tPatient[{Patient}]\t{DateOfAttendence}";
        }

        public string PrintMedicalRecord()
        {
            return $"Patient: {Patient.GetName()}\nRecord:\n\t Complain: {Complian}\n\t Diagnosis: {Diagnosis} \n\t Doctor's Name: {DoctorsName}\n\t Treatment: {Treatmeant}";
        }

        public string GetMedNumber()
        {
            return MedNumber;
        }

        // public MedicalRecord Parse(string line)
        // {
        //     string[] content = line.Split("\t");
        //     return new MedicalRecord();
        // }

    }
}