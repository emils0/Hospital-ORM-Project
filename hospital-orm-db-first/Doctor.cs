using System;
using System.Collections.Generic;

namespace Hospital_Project_DB_First;

public partial class Doctor
{
    public int Id { get; set; }

    public string? Specialty { get; set; }

    public virtual MedicalStaff IdNavigation { get; set; } = null!;
}
