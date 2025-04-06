using DentalWebApp.Models;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DentalWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; } //Incident
        public DbSet<Patient> Patients { get; set; } //Vehicle
        public DbSet<Dentist> Dentists { get; set; } //Employee


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Appointment Configuration
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Dentist)
                .WithMany()
                .HasForeignKey(a => a.DentistId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.SetNull);

            // Patient Configuration
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.PrimaryDentist)
                .WithMany(d => d.Patients)
                .HasForeignKey(p => p.PrimaryDentistId)
                .OnDelete(DeleteBehavior.SetNull);

            // Dentist Configuration
            modelBuilder.Entity<Dentist>()
                .HasMany(d => d.Patients)
                .WithOne(p => p.PrimaryDentist)
                .HasForeignKey(p => p.PrimaryDentistId)
                .OnDelete(DeleteBehavior.SetNull);

            // Property configurations
            modelBuilder.Entity<Dentist>()
                .Property(d => d.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Dentist>()
                .Property(d => d.LastName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Patient>()
                .Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Patient>()
                .Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Appointment>()
                .Property(a => a.Description)
                .HasMaxLength(500);
        }
    }
}



