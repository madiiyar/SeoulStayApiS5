using System;
using System.Collections.Generic;

namespace SeoulStayApiS5.Models;

public partial class ItemAttraction
{
    public long Id { get; set; }

    public Guid Guid { get; set; }

    public long ItemId { get; set; }

    public long AttractionId { get; set; }

    public decimal? Distance { get; set; }

    public long? DurationOnFoot { get; set; }

    public long? DurationByCar { get; set; }

    public virtual Attraction Attraction { get; set; } = null!;

    public virtual Item Item { get; set; } = null!;
}
