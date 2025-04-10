using IdentityService.Domain.Entities;
using IdentityService.Domain.Interfaces;
using IdentityService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task<User?> GetUserByCredentialsAsync(string username, string password)
    {
        return await context.Users
            .FirstOrDefaultAsync(u => u.Login == username && u.Password == password);
    }

    public Task<bool> UserExistsAsync(string username) =>
        context.Users.AnyAsync(x => x.Login == username);

    public async Task<bool> InsertUserAsync(string username, string password)
    {
        if (await UserExistsAsync(username))
            return false;

        var user = new User
        {
            Login = username,
            Password = password,
            CreatedAt = DateTime.Now
        };

        await context.Users.AddAsync(user);

        return await context.SaveChangesAsync() > 0;
    }
}