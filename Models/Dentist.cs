using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalWebApp.Models
{
    public class Dentist
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Description { get; set; }
        public virtual List<Patient>? Patients { get; set; }

        [NotMapped]
        public string FullName => $"Dr. {FirstName} {LastName}";
    }
}
