using MediatR;

namespace Abstractions.Requests.DeleteEntity;

public class DeleteEntityRequest : IRequest<DeleteEntityResponse>
{
    //plan to delete some entities
    public DeleteEntityRequest(int id) => Id = id;

    public int Id { get; set; }
}