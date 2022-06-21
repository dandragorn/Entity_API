using NUnit.Framework;

namespace Abstractions.Requests.GetEntities;

public class GetEntitiesResponse
{
    public GetEntitiesResponse(List<IEntity> entitiesList)
    {
        EntitiesList = entitiesList;
    }

    public List<IEntity> EntitiesList { get; }
}
