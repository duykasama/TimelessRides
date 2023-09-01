using System;
using System.Collections.Generic;

namespace OldCarShowroom.Service.Models;

public partial class Post
{
    public string Id { get; set; } = null!;

    public string? CarId { get; set; }

    public string? ClientId { get; set; }

    public string? Description { get; set; }

    public string? Plan { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime? PostDate { get; set; }

    public TimeSpan? PostTime { get; set; }

    public string? Status { get; set; }

    public int? Priority { get; set; }

    public virtual Car? Car { get; set; }

    public virtual Client? Client { get; set; }
}
