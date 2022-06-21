using Abstractions.Requests.AddEntity;
using App.Context;
using MediatR;


namespace App.Handlers;

public class AddEntityRequestHandler : IRequestHandler<AddEntityRequest,AddEntityResponse>
{
    private readonly EntityContext _context;
    public AddEntityRequestHandler(EntityContext context) => _context = context;
    
    public async Task<AddEntityResponse> Handle(AddEntityRequest request, CancellationToken cancellationToken)
    {
        var entity = new Entity
        {
            Id = request.Id,
            Title = request.Title,
            Description = request.Description,
            Content = request.Content
        };
        
        _context.Entities?.Add(entity ?? throw new InvalidOperationException());
        await _context.SaveChanges();
        return new AddEntityResponse(entity.Id);
    }
}