using System;
using System.Collections.Generic;

namespace Hospital_Project_DB_First;

public class MedicalStaff
{
	public int Id { get; set; }

	public string Name { get; set; }

	public string Qualification { get; set; }

	public int Experience { get; set; }

	public string Discriminator { get; set; } = null!;

	public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

	public virtual Doctor? Doctor { get; set; }

	public virtual Nurse? Nurse { get; set; }
}