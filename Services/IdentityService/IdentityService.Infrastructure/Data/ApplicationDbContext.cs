using IdentityService.Domain.Entities;
using IdentityService.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}
