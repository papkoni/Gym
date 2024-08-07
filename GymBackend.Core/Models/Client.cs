using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymBackend.Core.Models
{

    public class Client
	{
		public Client(int id,int id_user, string name, string lastname,
            string gender, DateTime birthday, string phone)
		{
            this.Id = id;
            this.Id_user = id_user;
            this.Name = name;
            this.Lastname = lastname;
            this.Gender = gender;
            this.Birthday = birthday;
            this.Phone = phone;

        }

        public int Id { get; }
        public int Id_user { get; }
        public string Name { get; } = String.Empty;

        public string Lastname { get; }

        public string Gender { get; } = String.Empty;

        public DateTime Birthday { get; }

        public string Phone { get; } = String.Empty;


    }
}

