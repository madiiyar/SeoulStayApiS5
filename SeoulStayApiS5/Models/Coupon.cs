using System;
using System.Collections.Generic;

namespace SeoulStayApiS5.Modelss;

public partial class Coupon
{
    public long Id { get; set; }

    public Guid Guid { get; set; }

    public string CouponCode { get; set; } = null!;

    public decimal DiscountPercent { get; set; }

    public decimal MaximimDiscountAmount { get; set; }

    public virtual ICollection<AddonService> AddonServices { get; set; } = new List<AddonService>();

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
