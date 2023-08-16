using System;
using System.Collections.Generic;

namespace Hospital_Project_DB_First;

public class Appointment
{
	public int Id { get; set; }

	public DateTime? Date { get; set; }

	public int? DoctorId { get; set; }

	public int? PatientId { get; set; }

	public virtual MedicalStaff? Doctor { get; set; }

	public virtual Patient? Patient { get; set; }
}