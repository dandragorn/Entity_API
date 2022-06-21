using MediatR;

namespace Abstractions.Requests.DeleteEntity;

public class DeleteEntityRequest : IRequest<DeleteEntityResponse>
{
    public DeleteEntityRequest(int id) => Id = id;

    public int Id { get; set; }
}