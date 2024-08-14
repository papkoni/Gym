using System;
namespace GymBackend.Core.Models
{
	public class User
	{
		public User(int id, string login, string password)
		{
			this.Id = id;
			this.Login = login;
			this.Password = password;


        }


        public User( string login, string password)
        {
           
            this.Login = login;
            this.Password = password;


        }

        public int Id { get; set; }

        public string Login { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}

