using System;
using System.Collections.Generic;

namespace P6ISA_API_RebecaRamirez.Models;

public partial class Project
{
    public int ProjectId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public int ClientId { get; set; }

    public int ProjectManagerId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ProjectManager ProjectManager { get; set; } = null!;

    public virtual ICollection<Task> TasksTasks { get; set; } = new List<Task>();
}
