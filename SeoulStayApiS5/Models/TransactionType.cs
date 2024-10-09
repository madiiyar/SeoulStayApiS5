using System;
using System.Collections.Generic;

namespace SeoulStayApiS5.Models;

public partial class TransactionType
{
    public long Id { get; set; }

    public Guid Guid { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
