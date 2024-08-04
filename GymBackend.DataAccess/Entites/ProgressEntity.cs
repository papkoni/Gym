using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GymBackend.DataAccess.Entites;

namespace GymBackend.DataAccess;

[Table("progress")]

public partial class ProgressEntity
{
    public int Id { get; set; }

    public int IdClient { get; set; }

    public byte[] Weight { get; set; } = null!;

    public byte[] HipChest { get; set; } = null!;

    public byte[] HipArm { get; set; } = null!;

    public byte[] HipGirth { get; set; } = null!;

    public DateTime Date { get; set; }

    public virtual ClientEntity IdClientNavigation { get; set; } = null!;
}
