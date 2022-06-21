using System.ComponentModel.DataAnnotations;
using Abstractions;

namespace App;

public class Entity : IEntity
{
    public Entity(){}
    
    public Entity(int id, string? title, string? content, string? description)
    {
        Id = id;
        Title = title;
        Description = description;
        Content = content;
    }

    [Key]
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
}