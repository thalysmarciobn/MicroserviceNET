using System;
using System.ComponentModel.DataAnnotations;
 
namespace IdentityService.Domain.Entities;

public class Entity<TKey> : IHasKey<TKey>, ITrackable
{
    
}