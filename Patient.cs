namespace Hospital_ORM_project; 

public class Patient
{
	public int Id { get; set; }
	public string Name { get; set; }
	public virtual ICollection<Appointment> Appointments { get; set; }
	public virtual MedicalRecord MedicalRecord { get; set; }
}
