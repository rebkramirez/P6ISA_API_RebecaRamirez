using System;
using System.Collections.Generic;

namespace P6ISA_API_RebecaRamirez.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string Name { get; set; } = null!;

    public string Identificacion { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Address { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
