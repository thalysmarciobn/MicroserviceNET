using System;
using System.ComponentModel.DataAnnotations;
using IdentityService.Domain.Interfaces;

namespace IdentityService.Domain.Entities;

public class Entity<TKey> : IHasKey<TKey>, ITrackable
{
    public TKey Id { get; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}