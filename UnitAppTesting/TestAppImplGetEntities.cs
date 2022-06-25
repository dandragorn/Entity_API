using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abstractions;
using Abstractions.Requests.AddEntity;
using Abstractions.Requests.GetEntities;
using App;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace UnitAppTesting;

[TestFixture]
public class TestAppImplGetEntities: TestHost
{
    [SetUp]
    public async Task Setup() => await Start();

    [Test]
    public async Task CanGetEntities()
    {
        var mediator = ServiceProvider?.GetRequiredService<IMediator>() ??
                       throw new ArgumentNullException(nameof(ServiceProvider));
        
        var addEntityRequest = new AddEntityRequest(1, "Title", "Description", "Content");
        var addResponse = await mediator.Send(addEntityRequest);
        Assert.AreEqual(1,addResponse.Id);

        var getEntitiesRequest = new GetEntitiesRequest(0, 1);
        var getEntitiesResponse = await mediator.Send(getEntitiesRequest);
        Assert.AreEqual(1,getEntitiesResponse.EntitiesList.Count());
    }
}