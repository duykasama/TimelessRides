using System;
using System.Collections.Generic;

namespace OldCarShowroom.Models.Models;

public partial class CarImage
{
    public string Id { get; set; } = null!;

    public string? CarId { get; set; }

    public string? Content { get; set; }

    public virtual Car? Car { get; set; }
}
