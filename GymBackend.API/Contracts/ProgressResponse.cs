using System;
namespace GymBackend.API.Contracts
{
    public record ProgressResponse(
        int id,
        int id_client,
        byte[] weight,
        byte[] hipChest,
        byte[] hipArm,
        byte[] hipGirth,
        DateTime date);
}

