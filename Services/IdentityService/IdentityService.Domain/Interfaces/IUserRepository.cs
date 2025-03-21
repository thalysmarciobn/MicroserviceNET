using IdentityService.Domain.Entities;

namespace IdentityService.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserByCredentialsAsync(string username, string password);
    Task<bool> InsertUserAsync(string username, string password);
}