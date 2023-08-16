using Hospital_ORM_project;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Hospital_ORM_project {
	public static class Program {
		public static void Main(string[] args) {
			Console.WriteLine("Starting the Hospital Management System...");

			// Create instances
			var doctor = new Doctor
				{Name = "Dr. Smith", Qualification = "MD", Experience = 10, Specialty = "Cardiology"};
			var nurse = new Nurse
				{Name = "Nurse Johnson", Qualification = "RN", Experience = 5, Department = "Surgery" };
			var patient = new Patient {Name = "John Doe"};
			var medicalRecord = new MedicalRecord {Details = "Medical history details", Patient = patient};
			var appointment = new Appointment {Date = DateTime.Now, Doctor = doctor, Patient = patient};

			// Add instances to the database
			using (var context = new HospitalContext()) {
				context.Database.EnsureCreated(); // Ensure the database is created

				context.Doctors.Add(doctor);
				context.Nurses.Add(nurse);
				context.Patients.Add(patient);
				context.MedicalRecords.Add(medicalRecord);
				context.Appointments.Add(appointment);

				context.SaveChanges(); // Save changes to the database
			}

			Console.WriteLine("Data added successfully!");
		}
	}

	public class HospitalContext : DbContext
	{
		public DbSet<Doctor> Doctors { get; set; }
		public DbSet<Nurse> Nurses { get; set; }
		public DbSet<Patient> Patients { get; set; }
		public DbSet<Appointment> Appointments { get; set; }
		public DbSet<MedicalRecord> MedicalRecords { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder.UseMySql("Server=localhost;Database=HospitalDB;User=root;",
				new MySqlServerVersion(new Version(11, 0, 2)));
		}
	}
}