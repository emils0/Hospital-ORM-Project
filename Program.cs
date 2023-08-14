using Hospital_ORM_project;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("test");

public class HospitalContext : DbContext
{
	public DbSet<Doctor> Doctors { get; set; }
	public DbSet<Nurse> Nurses { get; set; }
	public DbSet<Patient> Patients { get; set; }
	public DbSet<Appointment> Appointments { get; set; }
	public DbSet<MedicalRecord> MedicalRecords { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseMySql("Server=localhost;Database=HospitalDB;User=root;", 
			new MySqlServerVersion(new Version(11, 0, 2)));
	}

}

