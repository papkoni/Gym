using System;
namespace GymBackend.API.Contracts
{
    public record CreateClientRequest(
            ClientsRequest Clients,
            UsersRequest Users
        );
}

