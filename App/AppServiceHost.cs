using Abstractions;
using App.Context;
using App.Handlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace App;

public class AppServiceHost : AppServiceHostBase 
{
    protected override void RegisterServices(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddMediatR(typeof(AddEntityRequestHandler).Assembly);

        serviceCollection.AddDbContext<EntityContext>(
            options => options.UseSqlite(
                configuration.GetConnectionString("Entities") ?? "Data Source=EntityDb.db"));
    }

    protected override Task ConfigureServices(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        return Task.CompletedTask;
    }
}