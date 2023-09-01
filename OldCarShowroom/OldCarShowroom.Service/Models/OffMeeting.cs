using System;
using System.Collections.Generic;

namespace OldCarShowroom.Service.Models;

public partial class OffMeeting
{
    public string Id { get; set; } = null!;

    public string? StaffId { get; set; }

    public string? ClientId { get; set; }

    public string? CarId { get; set; }

    public string? Phone { get; set; }

    public DateTime? MeetingDate { get; set; }

    public TimeSpan? MeetingTime { get; set; }

    public DateTime? CreateDate { get; set; }

    public TimeSpan? CreateTime { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public virtual Car? Car { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Staff? Staff { get; set; }
}
