using System;
using System.Collections.Generic;

namespace SeoulStayApiS5.Models;

public partial class Area
{
    public long Id { get; set; }

    public Guid Guid { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Attraction> Attractions { get; set; } = new List<Attraction>();

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
