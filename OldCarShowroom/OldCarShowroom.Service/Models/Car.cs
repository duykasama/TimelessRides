using System;
using System.Collections.Generic;

namespace OldCarShowroom.Service.Models;

public partial class Car
{
    public string Id { get; set; } = null!;

    public string CarDescriptionId { get; set; } = null!;

    public string? ShowroomId { get; set; }

    public string? Name { get; set; }

    public long? Price { get; set; }

    public string? Status { get; set; }

    public virtual CarDescription CarDescription { get; set; } = null!;

    public virtual ICollection<CarImage> CarImages { get; set; } = new List<CarImage>();

    public virtual Invoice? Invoice { get; set; }

    public virtual ICollection<OffMeeting> OffMeetings { get; set; } = new List<OffMeeting>();

    public virtual Post? Post { get; set; }

    public virtual Showroom? Showroom { get; set; }
}
