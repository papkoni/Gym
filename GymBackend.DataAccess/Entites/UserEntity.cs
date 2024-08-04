using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GymBackend.DataAccess.Entites;

namespace GymBackend.DataAccess;

[Table("user")]

public partial class UserEntity
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<ClientEntity> Clients { get; set; } = new List<ClientEntity>();

    public virtual ICollection<CoachEntity> Coaches { get; set; } = new List<CoachEntity>();
}
