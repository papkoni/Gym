using System;
namespace GymBackend.Core.Models
{
	public class Progress
	{
		public Progress(int id, int idClient, byte[] weight, byte[] hipChest, byte[] hipArm, byte[] hipGirth, DateTime date)
		{
            this.Id = id;
            this.IdClient = idClient;
            this.Weight = weight;
            this.HipChest = hipChest;
            this.HipArm = hipArm;
            this.HipGirth = hipGirth;
            this.Date = date;

        }

        public int Id { get; set; }

        public int IdClient { get; set; }

        public byte[] Weight { get; set; } = null!;

        public byte[] HipChest { get; set; } = null!;

        public byte[] HipArm { get; set; } = null!;

        public byte[] HipGirth { get; set; } = null!;

        public DateTime Date { get; set; }
    }
}

