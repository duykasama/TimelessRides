using System;
using System.Collections.Generic;

namespace OldCarShowroom.Models.Models;

public partial class Staff
{
    public string Id { get; set; } = null!;

    public string? Role { get; set; }

    public string? ShowroomId { get; set; }

    public string? Name { get; set; }

    public string? Avatar { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Gender { get; set; }

    public string? Password { get; set; }

    public string? Address { get; set; }

    public DateTime? Dob { get; set; }

    public DateTime? JoinedAt { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<OffMeeting> OffMeetings { get; set; } = new List<OffMeeting>();

    public virtual Showroom? Showroom { get; set; }

    public virtual ICollection<StaffNotification> StaffNotifications { get; set; } = new List<StaffNotification>();
}
