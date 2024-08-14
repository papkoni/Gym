using System;
namespace GymBackend.API.Contracts
{
    public record ClientsRequest(
        
        string name,
        string lastname,
        string gender,
        DateTime birthday,
        string phone);
}

