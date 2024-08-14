using System;
using GymBackend.Core.Models;
using GymBackend.DataAccess.Repositories;

namespace GymBackend.Application.Services
{
	public class ClientService: IClientService
	{
		private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
		{
			_clientRepository = clientRepository;

        }

		public async Task<List<Client>> GetAllClients()
		{
			return await _clientRepository.GetAllClients();
        }

		public async Task<int> CreateClient(Client client,User user)
		{
			return await _clientRepository.CreateClient(client, user);
        }

		public async Task<int> UpdateClient(int id, int id_user, string name, string lastname, string gender, DateTime birthday, string phone)
		{
			return await _clientRepository.UpdateClient( id,  id_user,  name,  lastname,  gender,  birthday,  phone);
		}

		public async Task<int> DeleteClient(int id)
		{
			return await _clientRepository.DeleteClient(id);

        }

        public async Task<List<Progress>> GetClientProgress(int id)
		{
			return await _clientRepository.GetClientProgress(id);

        }



        }
}

