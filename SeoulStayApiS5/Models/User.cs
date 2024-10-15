using System;
using System.Collections.Generic;

namespace SeoulStayApiS5.Modelss;

public partial class User
{
    public long Id { get; set; }

    public Guid Guid { get; set; }

    public long UserTypeId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public bool Gender { get; set; }

    public DateOnly BirthDate { get; set; }

    public int FamilyCount { get; set; }

    public virtual ICollection<AddonService> AddonServices { get; set; } = new List<AddonService>();

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<ItemScore> ItemScores { get; set; } = new List<ItemScore>();

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual UserType UserType { get; set; } = null!;
}
