using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymBackend.Core.Models
{
    [Table("client")]

    public class Client
	{
		public Client(int id,int id_user, string name, string lastname,
            string gender, DateTime birthday, string phone)
		{
            this.id = id;
            this.id_user = id_user;
            this.name = name;
            this.lastname = lastname;
            this.gender = gender;
            this.birthday = birthday;
            this.phone = phone;

        }

        public int id { get; }
        public int id_user { get; }
        public string name { get; } = String.Empty;

        public string lastname { get; }

        public string gender { get; } = String.Empty;

        public DateTime birthday { get; }

        public string phone { get; } = String.Empty;


    }
}

