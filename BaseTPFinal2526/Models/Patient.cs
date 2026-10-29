namespace BaseTPFinal2526.Models
{
    public class Patient : Person
    {
        public DateTime BirthDate { get; set; }
        public string MedicalRecordNumber { get; set; }
        public bool IsInsured { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

    }
}
