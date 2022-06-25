using System;
using System.Threading.Tasks;
using Abstractions;
using Abstractions.Requests.AddEntity;
using Abstractions.Requests.DeleteEntity;
using App;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace UnitAppTesting;

[TestFixture]
public class TestAppImplDeleteData : TestHost
{
    [SetUp]
    public async Task Setup() => await Start();

    [Test]
    public async Task CanDeleteEntity()
    {
       var mediator = ServiceProvider?.GetRequiredService<IMediator>() ??
                      throw new ArgumentNullException(nameof(ServiceProvider));
       
       var addEntityRequest = new AddEntityRequest(1, "Title", "Description", "Content");
       var addResponse = await mediator.Send(addEntityRequest);
       Assert.NotZero(addResponse.Id);
       
       const int entityToDelete = 1;
       var deleteEntityRequest = new DeleteEntityRequest(entityToDelete);

       var deleteResponse = await mediator.Send(deleteEntityRequest);
       Assert.IsTrue(deleteResponse.Result);
    }
}