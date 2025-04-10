namespace IdentityService.Domain.Interfaces;

public interface IHasKey<out TKey>
{
    TKey Id { get; }
}