using System;
using System.Collections.Generic;

namespace P6ISA_API_RebecaRamirez.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string LoginPassword { get; set; } = null!;

    public int UserRoleId { get; set; }

    public virtual UserRole UserRole { get; set; } = null!;
}
