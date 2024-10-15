using SeoulStayApiS5.Modelss;
using System;
using System.Collections.Generic;

namespace SeoulStayApiS5.Models;

public partial class AddonServiceDetail
{
    public long Id { get; set; }

    public Guid Guid { get; set; }

    public long AddonServiceId { get; set; }

    public long ServiceId { get; set; }

    public decimal Price { get; set; }

    public DateTime FromDate { get; set; }

    public string Notes { get; set; } = null!;

    public long NumberOfPeople { get; set; }

    public bool IsRefund { get; set; }

    public virtual AddonService AddonService { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
