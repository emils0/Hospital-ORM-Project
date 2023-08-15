using System;
using Hospital_Project_DB_First;

namespace Hospital_Project_DB_First
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting the Hospital Management System...");

            // Create instances
            var doctorStaff = new MedicalStaff { Name = "Dr. Smith", Qualification = "MD", Experience = 10, Discriminator = "Doctor" };
            var nurseStaff = new MedicalStaff { Name = "Nurse Johnson", Qualification = "RN", Experience = 5, Discriminator = "Nurse" };

            // Add MedicalStaff instances to the database and save to generate Id values
            using (var context = new HospitalDbfirstContext())
            {
                context.MedicalStaffs.Add(doctorStaff);
                context.MedicalStaffs.Add(nurseStaff);
                context.SaveChanges();
            }

            // Now that Id values are generated, create Doctor and Nurse details
            var doctorDetail = new Doctor { Id = doctorStaff.Id, Specialty = "Cardiology" };
            var nurseDetail = new Nurse { Id = nurseStaff.Id, Department = "Surgery" };

            var patient = new Patient { Name = "John Doe" };

            // Add Patient, Doctor, and Nurse details to the database and save
            using (var context = new HospitalDbfirstContext())
            {
                context.Doctors.Add(doctorDetail);
                context.Nurses.Add(nurseDetail);
                context.Patients.Add(patient);
                context.SaveChanges();
            }

            // Now that Patient and Doctor have Id values generated, create Appointment and MedicalRecord
            var medicalRecord = new MedicalRecord { Details = "Medical history details", PatientId = patient.Id };
            var appointment = new Appointment { Date = DateTime.Now, DoctorId = doctorStaff.Id, PatientId = patient.Id };

            // Add remaining instances to the database
            using (var context = new HospitalDbfirstContext())
            {
                context.MedicalRecords.Add(medicalRecord);
                context.Appointments.Add(appointment);
                context.SaveChanges();
            }

            Console.WriteLine("Data added successfully!");
        }
    }
}
