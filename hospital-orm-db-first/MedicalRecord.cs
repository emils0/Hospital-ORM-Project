using System;
using System.Collections.Generic;

namespace Hospital_Project_DB_First;

public partial class MedicalRecord
{
    public int Id { get; set; }

    public string? Details { get; set; }

    public int? PatientId { get; set; }

    public virtual Patient? Patient { get; set; }
}
