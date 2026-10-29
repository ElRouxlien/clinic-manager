using BaseTPFinal2526.Models;

namespace BaseTPFinal2526.Validators
{
    public class PatientsValidator : PersonsValidator
    {
        public bool IsValid(Patient patient)
        {
            return base.IsValid(patient)
                && IsBirthDateValid(patient.BirthDate)
                && IsMedicalRecordNumberValid(patient.MedicalRecordNumber);
        }

        private bool IsBirthDateValid(DateTime birthDate)
        {
            if (birthDate > DateTime.Now)
                return false;

            if (birthDate < new DateTime(1900, 1, 1))
                return false;

            return true;
        }

        private bool IsMedicalRecordNumberValid(string mrn)
        {
            if (string.IsNullOrWhiteSpace(mrn))
                return false;

            if (mrn.Length < 4)
                return false;

            return true;
        }
    }
}
