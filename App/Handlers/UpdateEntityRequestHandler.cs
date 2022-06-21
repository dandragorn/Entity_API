using Abstractions.Requests.UpdateEntity;
using App.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;

namespace App.Handlers;

public class UpdateEntityRequestHandler : IRequestHandler<UpdateEntityRequest, UpdateEntityResponse>
{
    private readonly EntityContext _context;
    public UpdateEntityRequestHandler(EntityContext context) => _context = context;


    public async Task<UpdateEntityResponse> Handle(UpdateEntityRequest request, CancellationToken cancellationToken)
    {
        var entity = await _context
            .Entities!
            .Where(a => a.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        _= entity ?? throw new NotImplementedException("Some message");

        entity.Id = request.Id;
        entity.Title = request.Title;
        entity.Description = request.Description;
        entity.Content = request.Content;

        await _context.SaveChangesAsync(cancellationToken);
        return new UpdateEntityResponse(entity.Title);
    }
}