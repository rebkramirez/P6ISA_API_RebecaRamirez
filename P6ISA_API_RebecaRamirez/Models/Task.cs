using System;
using System.Collections.Generic;

namespace P6ISA_API_RebecaRamirez.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string Status { get; set; } = null!;

    public int EngineerId { get; set; }

    public virtual Engineer Engineer { get; set; } = null!;

    public virtual ICollection<Project> ProjectsProjects { get; set; } = new List<Project>();
}
