using System;
using System.Threading.Tasks;
using Abstractions;
using Abstractions.Requests.AddEntity;
using App;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace UnitAppTesting;

[TestFixture]
public class TestAppImplAddData: TestHost
{
    [SetUp] 
    public async Task Setup() => await Start();

    [Test]
    public async Task CanAddEntity()
    {
        var mediator = ServiceProvider?.GetRequiredService<IMediator>() ??
                       throw new ArgumentNullException(nameof(ServiceProvider));
        
        //var newEntity = new Entity(1, "Title", "Description", "Content") as IEntity;
        var addEntityRequest = new AddEntityRequest(1, "Title", "Description", "Content");
        
        var addResponse = await mediator.Send(addEntityRequest);
        Assert.NotZero(addResponse.Id);
    }
}