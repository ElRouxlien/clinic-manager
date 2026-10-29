using BaseTPFinal2526.Models;
using BaseTPFinal2526.Models.Enums;
using BaseTPFinal2526.Repositories;
using System.Text.RegularExpressions;

namespace BaseTPFinal2526.Validators
{
    public class DoctorsValidator : PersonsValidator
    {
        private readonly DoctorsRepository _doctorsRepository;
        public DoctorsValidator(DoctorsRepository doctorsRepository)
        {
            _doctorsRepository = doctorsRepository;
        }

        public bool IsValid(Doctor doctor)
        {
            return base.IsValid(doctor)
                && IsSpecialtyValid(doctor.Specialty)
                && IsInamiValid(doctor.INAMINumber)
                && IsInamiUnique(doctor)
                && IsConsultationFeeValid(doctor.ConsultationFee);
        }

        private bool IsSpecialtyValid(DoctorSpeciality specialty)
        {
            return specialty != DoctorSpeciality.Unknown;
        }

        private bool IsInamiValid(string inamiNumber)
        {
            var inamiRegex = new Regex(@"^[0-9]{11}$", RegexOptions.Compiled);
            if (string.IsNullOrWhiteSpace(inamiNumber))
                return false;

            return inamiRegex.IsMatch(inamiNumber);
        }
        private bool IsInamiUnique(Doctor doctor)
        {
            var existing = _doctorsRepository.GetByINAMINumber(doctor.INAMINumber);

            if (existing == null)
                return true;

            if (existing.Id == doctor.Id)
                return true;

            return false;
        }

        private bool IsConsultationFeeValid(decimal fee)
        {
            return fee > 0;
        }
    }
}
