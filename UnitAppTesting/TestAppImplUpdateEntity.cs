using System;
using System.Threading.Tasks;
using Abstractions.Requests.AddEntity;
using Abstractions.Requests.UpdateEntity;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace UnitAppTesting;

[TestFixture]
public class TestAppImplUpdateEntity: TestHost
{
    [SetUp]
    public async Task Setup() => await Start();

    [Test]
    public async Task CanUpdateEntity()
    {
        var mediator = ServiceProvider?.GetRequiredService<IMediator>() ??
                       throw new ArgumentNullException(nameof(ServiceProvider));
        
        var addEntityRequest = new AddEntityRequest(1, "Title", "Description", "Content");
        
        var addResponse = await mediator.Send(addEntityRequest);
        Assert.AreEqual(1,addResponse.Id);

        var updateEntityRequest = new UpdateEntityRequest(1, "NewTitle", "NewDescription", "NewContent");
        var response = await mediator.Send(updateEntityRequest);
        
        Assert.AreEqual("NewTitle", response.Title);
    }
    
}