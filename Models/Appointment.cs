using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalWebApp.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Appointment Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime AppointmentDate { get; set; }
        [Required]
        [Display(Name = "Duration (minutes)")]
        public int Duration { get; set; }
        [Display(Name = "Dentist")]
        public int? DentistId { get; set; }
        [ForeignKey("DentistId")]
        [Display(Name = "Dentist")]
        public virtual Dentist? Dentist { get; set; }
        [Display(Name = "Patient")]
        public int? PatientId { get; set; }
        [ForeignKey("PatientId")]
        [Display(Name = "Patient")]
        public virtual Patient? Patient { get; set; }
        public string Description { get; set; }
    }
}
