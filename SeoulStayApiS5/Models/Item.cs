using System;
using System.Collections.Generic;

namespace SeoulStayApiS5.Modelss;

public partial class Item
{
    public long Id { get; set; }

    public Guid Guid { get; set; }

    public long UserId { get; set; }

    public long ItemTypeId { get; set; }

    public long AreaId { get; set; }

    public string Title { get; set; } = null!;

    public int Capacity { get; set; }

    public int NumberOfBeds { get; set; }

    public int NumberOfBedrooms { get; set; }

    public int NumberOfBathrooms { get; set; }

    public string ExactAddress { get; set; } = null!;

    public string ApproximateAddress { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string HostRules { get; set; } = null!;

    public int MinimumNights { get; set; }

    public int MaximumNights { get; set; }

    public virtual Area Area { get; set; } = null!;

    public virtual ICollection<ItemAmenity> ItemAmenities { get; set; } = new List<ItemAmenity>();

    public virtual ICollection<ItemAttraction> ItemAttractions { get; set; } = new List<ItemAttraction>();

    public virtual ICollection<ItemPicture> ItemPictures { get; set; } = new List<ItemPicture>();

    public virtual ICollection<ItemPrice> ItemPrices { get; set; } = new List<ItemPrice>();

    public virtual ICollection<ItemScore> ItemScores { get; set; } = new List<ItemScore>();

    public virtual ItemType ItemType { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
