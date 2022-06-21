using System.ComponentModel.DataAnnotations;

namespace Abstractions;

public interface IEntity
{
    public int Id { get; }
    public string? Title { get; }
    public string? Description { get; }
    public string? Content { get; }
    
}