using Hospital_Project_DB_First;


Console.WriteLine("Starting the Hospital Management System...");
var context = new HospitalDbfirstContext();

var doctorStaff = new MedicalStaff { Name = "Dr. Smith", Qualification = "MD", Experience = 10, Discriminator = "Doctor" };
var nurseStaff = new MedicalStaff { Name = "Nurse Johnson", Qualification = "RN", Experience = 5, Discriminator = "Nurse" };


context.MedicalStaffs.Add(doctorStaff);
context.MedicalStaffs.Add(nurseStaff);
context.SaveChanges();


var doctorDetail = new Doctor { Id = doctorStaff.Id, Specialty = "Cardiology" };
var nurseDetail = new Nurse { Id = nurseStaff.Id, Department = "Surgery" };

var patient = new Patient { Name = "John Doe" };


context.Doctors.Add(doctorDetail);
context.Nurses.Add(nurseDetail);
context.Patients.Add(patient);
context.SaveChanges();


var medicalRecord = new MedicalRecord { Details = "Medical history details", PatientId = patient.Id };
var appointment = new Appointment { Date = DateTime.Now, DoctorId = doctorStaff.Id, PatientId = patient.Id };


context.MedicalRecords.Add(medicalRecord);
context.Appointments.Add(appointment);
context.SaveChanges();


Console.WriteLine("Data added successfully!");