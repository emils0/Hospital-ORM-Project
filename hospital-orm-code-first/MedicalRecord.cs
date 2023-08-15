namespace Hospital_ORM_project; 

public class MedicalRecord
{
	public int Id { get; set; }
	public string Details { get; set; }
	public int PatientId { get; set; }
	public virtual Patient Patient { get; set; }
}
