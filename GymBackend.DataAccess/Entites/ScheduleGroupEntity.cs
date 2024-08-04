using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymBackend.DataAccess;

[Table("schedule_group")]

public partial class ScheduleGroupEntity
{
    public int Id { get; set; }

    public int IdCoach { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string TypeOfTraining { get; set; } = null!;

    public int MaxPeople { get; set; }

    public virtual CoachEntity IdCoachNavigation { get; set; } = null!;

    public virtual ICollection<RegistrationEntity> Registrations { get; set; } = new List<RegistrationEntity>();

    public virtual ICollection<VisitEntity> Visits { get; set; } = new List<VisitEntity>();
}
