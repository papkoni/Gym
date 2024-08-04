using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GymBackend.DataAccess.Entites;

namespace GymBackend.DataAccess;

[Table("visit")]

public partial class VisitEntity
{
    public int Id { get; set; }

    public int IdClient { get; set; }

    public int? IdScheduleGroup { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public virtual ClientEntity IdClientNavigation { get; set; } = null!;

    public virtual ScheduleGroupEntity? IdScheduleGroupNavigation { get; set; }
}
