using System;
using System.Collections.Generic;

namespace OldCarShowroom.Models.Models;

public partial class Admin
{
    public string Id { get; set; } = null!;

    public string? Role { get; set; }

    public string? Name { get; set; }

    public string? Avatar { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}
