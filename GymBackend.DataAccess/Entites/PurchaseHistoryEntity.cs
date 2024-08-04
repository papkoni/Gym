using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GymBackend.DataAccess.Entites;

namespace GymBackend.DataAccess;

[Table("purchase_history")]

public partial class PurchaseHistoryEntity
{
    public int Id { get; set; }

    public int IdClient { get; set; }

    public int IdSubscription { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public virtual ClientEntity IdClientNavigation { get; set; } = null!;

    public virtual SubscriptionEntity IdSubscriptionNavigation { get; set; } = null!;
}
