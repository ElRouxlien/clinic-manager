using BaseTPFinal2526.Models.Enums;

namespace BaseTPFinal2526.Models
{
    public class Doctor : Person
    {
        public DoctorSpeciality Specialty { get; set; }
        public string INAMINumber { get; set; }
        public decimal ConsultationFee { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

    }
}
