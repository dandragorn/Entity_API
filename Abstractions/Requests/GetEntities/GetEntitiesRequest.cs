using Abstractions.Requests.UpdateEntity;
using MediatR;

namespace Abstractions.Requests.GetEntities;

public class GetEntitiesRequest: IRequest<GetEntitiesResponse>
{
    public int SkipQuantity, GetQuantity;

    public GetEntitiesRequest(int skip, int show)
    {
        SkipQuantity = skip;
        GetQuantity = show;
    }
    
}