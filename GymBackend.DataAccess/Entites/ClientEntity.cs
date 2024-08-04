using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymBackend.DataAccess.Entites
{
    [Table("client")]

    public class ClientEntity
	{
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Lastname { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public DateTime Birthday { get; set; }

        public string Phone { get; set; } = null!;

        public int IdUser { get; set; }

        public virtual UserEntity IdUserNavigation { get; set; } = null!;

        public virtual ICollection<ProgressEntity> Progresses { get; set; } = new List<ProgressEntity>();

        public virtual ICollection<PurchaseHistoryEntity> PurchaseHistories { get; set; } = new List<PurchaseHistoryEntity>();

        public virtual ICollection<RegistrationEntity> Registrations { get; set; } = new List<RegistrationEntity>();

        public virtual ICollection<VisitEntity> Visits { get; set; } = new List<VisitEntity>();

    }
}

