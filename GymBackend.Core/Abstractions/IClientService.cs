using GymBackend.Core.Models;

namespace GymBackend.Application.Services
{
    public interface IClientService
    {
        Task<int> CreateClient(Client client);
        Task<int> DeleteClient(int id);
        Task<List<Client>> GetAllClients();
        Task<int> UpdateClient(int id, int id_user, string name, string lastname, string gender, DateTime birthday, string phone);
    }
}