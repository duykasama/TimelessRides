using System;
using System.Collections.Generic;

namespace OldCarShowroom.Service.Models;

public partial class Client
{
    public string Id { get; set; } = null!;

    public string? Role { get; set; }

    public string? Name { get; set; }

    public string? Avatar { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Address { get; set; }

    public string? Gender { get; set; }

    public DateTime? Dob { get; set; }

    public DateTime? JoinAt { get; set; }

    public virtual ICollection<ClientNotification> ClientNotifications { get; set; } = new List<ClientNotification>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<OffMeeting> OffMeetings { get; set; } = new List<OffMeeting>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
