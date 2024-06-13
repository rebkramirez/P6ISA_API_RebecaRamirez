using System;
using System.Collections.Generic;

namespace P6ISA_API_RebecaRamirez.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Engineer> Engineers { get; set; } = new List<Engineer>();

    public virtual ICollection<ProjectManager> ProjectManagers { get; set; } = new List<ProjectManager>();
}
