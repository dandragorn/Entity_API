using Abstractions.Requests.DeleteEntity;
using App.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Handlers;

public class DeleteEntityRequestHandler : IRequestHandler<DeleteEntityRequest,DeleteEntityResponse>
{
    private readonly EntityContext _context;
    public DeleteEntityRequestHandler(EntityContext context) => _context = context;
    
    public async Task<DeleteEntityResponse> Handle(DeleteEntityRequest request, CancellationToken cancellationToken)
    {
        var entity =
            _context
                .Entities!
                .Where(a => a.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        
        _context.Entities?.Remove(await entity ?? throw new InvalidOperationException("There's no such ID, try harder"));
        
        await _context.SaveChanges();
        return new DeleteEntityResponse(true);
    }
}