using System;
using System.Collections.Generic;

namespace OldCarShowroom.Models.Models;

public partial class Showroom
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
