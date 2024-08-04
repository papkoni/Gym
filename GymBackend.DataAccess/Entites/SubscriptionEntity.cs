using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymBackend.DataAccess;

[Table("subscription")]

public partial class SubscriptionEntity
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public double Price { get; set; }

    public virtual ICollection<PurchaseHistoryEntity> PurchaseHistories { get; set; } = new List<PurchaseHistoryEntity>();
}
