using System;
using System.Collections.Generic;

namespace P6ISA_API_RebecaRamirez.Models;

public partial class Engineer
{
    public int EngineerId { get; set; }

    public string Name { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public int DepartmentId { get; set; }

    public int EngineersEngineerId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
