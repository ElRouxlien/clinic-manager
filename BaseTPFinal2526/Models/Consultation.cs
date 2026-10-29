using BaseTPFinal2526.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BaseTPFinal2526.Models
{
    public class Consultation
    {
        public int Id { get; set; }

        [Required]
        public Doctor Doctor { get; set; }

        [Required]
        public Patient Patient { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Duration { get; set; } // en minutes

        [Required]
        public ConsultationType Type { get; set; }

        public ConsultationStatus Status { get; set; }

        public decimal TotalFee { get; set; }
    }
}
