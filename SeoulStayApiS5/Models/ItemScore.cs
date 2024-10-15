using System;
using System.Collections.Generic;

namespace SeoulStayApiS5.Modelss;

public partial class ItemScore
{
    public long Id { get; set; }

    public Guid Guid { get; set; }

    public long UserId { get; set; }

    public long ItemId { get; set; }

    public long ScoreId { get; set; }

    public long Value { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual Score Score { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
