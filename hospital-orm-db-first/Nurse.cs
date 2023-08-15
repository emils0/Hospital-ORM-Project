using System;
using System.Collections.Generic;

namespace Hospital_Project_DB_First;

public partial class Nurse
{
    public int Id { get; set; }

    public string? Department { get; set; }

    public virtual MedicalStaff IdNavigation { get; set; } = null!;
}
