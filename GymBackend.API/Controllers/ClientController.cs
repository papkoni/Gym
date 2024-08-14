using System;
using System.Linq;
using GymBackend.API.Contracts;
using GymBackend.Application.Services;
using GymBackend.Core.Models;
using GymBackend.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GymBackend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;

        }

        [HttpGet("AllClients")]
        public async Task<ActionResult<List<ClientsResponse>>> GetAllClients()
        {
            var clients = await _clientService.GetAllClients();

            var response = clients.Select(b => new ClientsResponse(b.Id, b.Id_user, b.Name, b.Lastname, b.Gender, b.Birthday, b.Phone));

            return Ok(response);
        }

        [HttpGet("ClientProgress")]
        public async Task<ActionResult<List<ProgressResponse>>> GetClientProgress(int id)
        {
            var progress = await _clientService.GetClientProgress(id);

            var response = progress.Select(b => new ProgressResponse(b.Id, b.IdClient, b.Weight, b.HipChest, b.HipArm, b.HipGirth, b.Date));

            return Ok(response);
        }

        [HttpPost("Create")]

        public async Task<ActionResult<int>> CreateClient([FromBody] CreateClientRequest request)
        {
            var client = new Client(request.Clients.name, request.Clients.lastname, request.Clients.gender, request.Clients.birthday, request.Clients.phone);

            var user = new User(request.Users.login, request.Users.password);

            await _clientService.CreateClient(client, user);

            return Ok(client.Id_user);


        }



    }
}

