using System;
using System.Threading.Tasks;
using App;
using App.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UnitAppTesting;

public class TestHost: AppServiceHost
{
    protected override async Task ConfigureServices(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        using var scope = serviceProvider.CreateScope();
        await using var db = scope.ServiceProvider.GetRequiredService<EntityContext>();
        await db.Database.EnsureDeletedAsync();
        await db.Database.EnsureCreatedAsync();
    }
}
