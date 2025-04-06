using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalWebApp.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        public DateOnly DateOfBirth { get; set; }
        public virtual List<Appointment>? Appointments { get; set; }
        [Display(Name = "Dentist")]
        public int? PrimaryDentistId { get; set; }
        [ForeignKey("PrimaryDentistId")]
        [Display(Name = "Dentist")]
        public virtual Dentist? PrimaryDentist { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}
