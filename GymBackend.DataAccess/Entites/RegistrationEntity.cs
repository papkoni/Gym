using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GymBackend.DataAccess.Entites;

namespace GymBackend.DataAccess;

[Table("registration")]

public partial class RegistrationEntity
{
    public int Id { get; set; }

    public int IdClient { get; set; }

    public int IdScheduleGroup { get; set; }

    public DateTime FromDate { get; set; }

    public bool? Deleted { get; set; }

    public virtual ClientEntity IdClientNavigation { get; set; } = null!;

    public virtual ScheduleGroupEntity IdScheduleGroupNavigation { get; set; } = null!;
}
