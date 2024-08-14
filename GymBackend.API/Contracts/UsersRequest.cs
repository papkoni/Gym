using System;
namespace GymBackend.API.Contracts
{
    public record UsersRequest(
            string password,
            string login
        );
}

