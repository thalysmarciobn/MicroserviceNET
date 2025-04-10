namespace IdentityService.Domain.Interfaces;

public interface ITrackable
{
    DateTime CreatedAt { get; set; }
    DateTime? UpdatedAt { get; set; }
}