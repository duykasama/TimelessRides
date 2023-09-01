using System;
using System.Collections.Generic;

namespace OldCarShowroom.Service.Models;

public partial class ClientNotification
{
    public string Id { get; set; } = null!;

    public string? ReceiverId { get; set; }

    public string? Content { get; set; }

    public DateTime? CreateDate { get; set; }

    public TimeSpan? CreateTime { get; set; }

    public string? Status { get; set; }

    public virtual Client? Receiver { get; set; }
}
