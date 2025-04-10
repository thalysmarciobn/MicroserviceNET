using IdentityService.Domain.Interfaces;

namespace IdentityService.Domain.Entities;

public class User : Entity<Guid>, IAggregateRoot
{
    public required string Login { get; set; }
    public required string Password { get; set; }
}