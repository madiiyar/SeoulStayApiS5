using System;
using System.Collections.Generic;

namespace SeoulStayApiS5.Models;

public partial class AddonService
{
    public long Id { get; set; }

    public Guid Guid { get; set; }

    public long UserId { get; set; }

    public long? CouponId { get; set; }

    public virtual ICollection<AddonServiceDetail> AddonServiceDetails { get; set; } = new List<AddonServiceDetail>();

    public virtual Coupon? Coupon { get; set; }

    public virtual User User { get; set; } = null!;
}
