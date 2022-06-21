using Abstractions;
using Microsoft.EntityFrameworkCore;

namespace App.Context;

public interface IEntityContext
{
    DbSet<Entity>? Entities { get; set; }
    Task<int> SaveChanges();
}