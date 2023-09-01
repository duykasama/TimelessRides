using System;
using System.Collections.Generic;

namespace OldCarShowroom.Service.Models;

public partial class Feedback
{
    public string Id { get; set; } = null!;

    public string? ClientId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Description { get; set; }

    public double? Rating { get; set; }

    public virtual Client? Client { get; set; }
}
