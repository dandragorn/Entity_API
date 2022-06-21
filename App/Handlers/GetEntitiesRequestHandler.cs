using Abstractions;
using Abstractions.Requests.GetEntities;
using App.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Handlers;

public class GetEntitiesRequestHandler : IRequestHandler<GetEntitiesRequest, GetEntitiesResponse>
{
    private readonly EntityContext _context;
    public GetEntitiesRequestHandler(EntityContext context) => _context = context; 
    
    public async Task<GetEntitiesResponse> Handle(GetEntitiesRequest request, CancellationToken cancellationToken)
    {
        var entitiesList = await _context.Entities!
            .Where(i => true)
            .OrderBy(i => i.Id)
            .Skip(request.SkipQuantity)
            .Take(request.GetQuantity)
            .ToListAsync(cancellationToken: cancellationToken);
        
        return new GetEntitiesResponse(new List<IEntity>(entitiesList));
    }
}
