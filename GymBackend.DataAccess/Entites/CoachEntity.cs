using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymBackend.DataAccess;

[Table("coach")]

public partial class CoachEntity
{

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Qualification { get; set; } = null!;

    public int IdUser { get; set; }

    public DateTime HiringDate { get; set; }

    public DateTime? TerminationDate { get; set; }

    public virtual UserEntity IdUserNavigation { get; set; } = null!;

    public virtual ICollection<ScheduleGroupEntity> ScheduleGroups { get; set; } = new List<ScheduleGroupEntity>();

}
