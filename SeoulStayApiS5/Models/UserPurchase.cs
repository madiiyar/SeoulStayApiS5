using System;
using System.Collections.Generic;

namespace SeoulStayApiS5.Modelss;

public partial class UserPurchase
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public string Service { get; set; } = null!;

    public decimal TotalPrice { get; set; }

    public DateTime Date { get; set; }

    public string? UserNotes { get; set; }

    public long NumberOfPeople { get; set; }

    public string Refunded { get; set; } = null!;
}
