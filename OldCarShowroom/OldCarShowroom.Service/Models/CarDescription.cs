using System;
using System.Collections.Generic;

namespace OldCarShowroom.Service.Models;

public partial class CarDescription
{
    public string Id { get; set; } = null!;

    public string? Make { get; set; }

    public string? Model { get; set; }

    public string? BodyColor { get; set; }

    public string? InteriorColor { get; set; }

    public string? InteriorMaterial { get; set; }

    public string? Body { get; set; }

    public string? LicensePlate { get; set; }

    public string? FuelType { get; set; }

    public string? Transmission { get; set; }

    public string? FirstRegistration { get; set; }

    public int? Seats { get; set; }

    public string? Power { get; set; }

    public string? EngineCapacity { get; set; }

    public string? Co2Emission { get; set; }

    public string? Mileage { get; set; }

    public string? Others { get; set; }

    public virtual Car? Car { get; set; }
}
