using Abstractions.Requests.AddEntity;
using MediatR;

namespace Abstractions.Requests.UpdateEntity;

public class UpdateEntityRequest : IRequest<UpdateEntityResponse>
{
    public UpdateEntityRequest(int id, string title, string description, string content)
    {
        Id = id;
        Title = title;
        Description = description;
        Content = content;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
}