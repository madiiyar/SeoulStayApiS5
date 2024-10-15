using SeoulStayApiS5.Models;
using System;
using System.Collections.Generic;

namespace SeoulStayApiS5.Modelss;

public partial class Service
{
    public long Id { get; set; }

    public Guid Guid { get; set; }

    public long ServiceTypeId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public long? Duration { get; set; }

    public string Description { get; set; } = null!;

    public string DayOfWeek { get; set; } = null!;

    public string DayOfMonth { get; set; } = null!;

    public long DailyCap { get; set; }

    public long BookingCap { get; set; }

    public virtual ICollection<AddonServiceDetail> AddonServiceDetails { get; set; } = new List<AddonServiceDetail>();

    public virtual ServiceType ServiceType { get; set; } = null!;
}
