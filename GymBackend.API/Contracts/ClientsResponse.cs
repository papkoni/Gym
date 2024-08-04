using System;
namespace GymBackend.API.Contracts
{
	public record ClientsResponse(
		int id,
		int id_user,
		string name,
		string lastname,
		string gender,
		DateTime birthday,
		string phone);
}

