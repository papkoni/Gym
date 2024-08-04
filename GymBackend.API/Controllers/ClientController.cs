using System;
using GymBackend.API.Contracts;
using GymBackend.Application.Services;
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

        [HttpGet]
        public async Task<ActionResult<List<ClientsResponse>>> GetAllClients()
        {
            var clients = await _clientService.GetAllClients();

            var response = clients.Select(b => new ClientsResponse(b.id, b.id_user, b.name, b.lastname, b.gender, b.birthday, b.phone));

            return Ok(response);
        }


	}
}

