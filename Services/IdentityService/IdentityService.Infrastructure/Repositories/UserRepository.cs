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

    public async Task<bool> InsertUserAsync(string username, string password)
    {
        await using var transaction = await context.Database.BeginTransactionAsync();

        try
        {
            if (await context.Users.AnyAsync(x => x.Login == username))
            {
                return false;
            }

            await context.Users.AddAsync(new User
            {
                Login = username,
                Password = password,
                CreatedAt = DateTime.Now
            });

            await context.SaveChangesAsync();
            
            await transaction.CommitAsync();
            
            return true;
        }
        catch
        {
            await transaction.RollbackAsync();
            
            return false;
        }
    }
}