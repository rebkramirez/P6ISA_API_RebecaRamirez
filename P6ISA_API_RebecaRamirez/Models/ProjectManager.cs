using System;
using System.Collections.Generic;

namespace P6ISA_API_RebecaRamirez.Models;

public partial class ProjectManager
{
    public int ProjectManagerId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
