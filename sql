
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
        public string FullName => $"{FirstName} {LastName}";
    }
        public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }

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
        [Display(Name = "DoB")]
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

    Според тези класове със свойства искам да ми построиш SQL скрипт, който да създаде примерни данни съответстващи на моделите.