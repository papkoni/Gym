
using System;
using GymBackend.Core.Models;
using GymBackend.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;

namespace GymBackend.DataAccess.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly CourseworkContext _context;
        public ClientRepository(CourseworkContext context)
        {
            _context = context;

        }


        public async Task<List<Client>> GetAllClients()
        {
            var clientEntites = await _context.Clients
                .AsNoTracking()
                .ToListAsync();

            var clients = clientEntites
                .Select(c => new Client(c.Id, c.IdUser, c.Name, c.Lastname, c.Gender, c.Birthday, c.Phone))
                .ToList();

            return clients;
        }


        public async Task<List<Progress>> GetClientProgress(int id)
        {

            Console.WriteLine(id + "    gfsgdf");


            var clientEntity = await _context.Clients
                .AsNoTracking()
                .Include(c => c.Progresses)
                .FirstOrDefaultAsync(c => c.Id == id);



            Console.WriteLine(_context.Clients.Count(c => c.Id == id) + "response");



            if (clientEntity != null)
            {
                var resultList = new List<Progress>();
                foreach (var progress in clientEntity.Progresses)
                {
                    resultList.Add(new Progress(progress.Id, progress.IdClient, progress.Weight, progress.HipChest,
                        progress.HipArm, progress.HipGirth, progress.Date));
                }
                return resultList;
            }
            Console.WriteLine("fdgfdag");
            return new List<Progress>();
        }


        public async Task<int> CreateClient(Client client)
        {
            var clientEntity = new ClientEntity
            {
                Id = client.Id,
                IdUser = client.Id_user,
                Name = client.Name,
                Lastname = client.Lastname,
                Gender = client.Gender,
                Birthday = client.Birthday,
                Phone = client.Phone,
            };

            await _context.Clients.AddAsync(clientEntity);
            await _context.SaveChangesAsync();

            return clientEntity.Id;
        }

        public async Task<int> UpdateClient(int id, int id_user, string name, string lastname, string gender, DateTime birthday, string phone)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);


            client.Name = name;
            client.Lastname = lastname;
            client.Gender = gender;
            client.Birthday = birthday;
            client.Phone = phone;

            await _context.SaveChangesAsync();

            return client.Id;
        }

        public async Task<int> DeleteClient(int id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);


            _context.Clients.Remove(client);
            return client.Id;
        }




    }
}

