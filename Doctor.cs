namespace Hospital_ORM_project; 

public class Doctor : MedicalStaff
{
	public string Specialty { get; set; }
	public virtual ICollection<Appointment> Appointments { get; set; }
}
