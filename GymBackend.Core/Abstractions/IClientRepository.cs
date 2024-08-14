using GymBackend.Core.Models;

namespace GymBackend.DataAccess.Repositories
{
    public interface IClientRepository
    {
        Task<int> CreateClient(Client client, User user);
        Task<int> DeleteClient(int id);
        Task<List<Client>> GetAllClients();
        Task<int> UpdateClient(int id, int id_user, string name, string lastname, string gender, DateTime birthday, string phone);
        Task<List<Progress>> GetClientProgress(int id);
        Task<int> CreateUser(User user);
    }
}