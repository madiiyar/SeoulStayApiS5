using System;
using System.Collections.Generic;

namespace SeoulStayApiS5.Models;

public partial class ServiceType
{
    public long Id { get; set; }

    public Guid Guid { get; set; }

    public string Name { get; set; } = null!;

    public string IconName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
