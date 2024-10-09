using System;
using System.Collections.Generic;

namespace SeoulStayApiS5.Models;

public partial class Booking
{
    public long Id { get; set; }

    public Guid Guid { get; set; }

    public long UserId { get; set; }

    public DateTime BookingDate { get; set; }

    public long? CouponId { get; set; }

    public long? TransactionId { get; set; }

    public decimal? AmountPaid { get; set; }

    public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();

    public virtual Coupon? Coupon { get; set; }

    public virtual Transaction? Transaction { get; set; }

    public virtual User User { get; set; } = null!;
}
