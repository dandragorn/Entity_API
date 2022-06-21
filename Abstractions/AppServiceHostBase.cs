using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Abstractions;

public abstract class AppServiceHostBase
{
    private IConfiguration? _configuration;
    public IServiceProvider? ServiceProvider;


    public async Task Start(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        _configuration = configuration;

        var loggerConfiguration = new LoggerConfiguration();
        ConfigureLogger(loggerConfiguration, _configuration);

        RegisterServices(serviceCollection, _configuration);
        ServiceProvider = serviceCollection.BuildServiceProvider();

        await ConfigureServices(ServiceProvider, _configuration);
    }

    public async Task Start()
    {
        var serviceCollection = new ServiceCollection();
        var configurationBuilder = new ConfigurationBuilder();
        SetupConfiguration(configurationBuilder);
        var configuration = configurationBuilder.Build();
        await Start(serviceCollection, configuration);
    }

    protected virtual void RegisterServices(IServiceCollection serviceCollection, IConfiguration configuration)
    {
    }

    protected virtual Task ConfigureServices(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        return Task.CompletedTask;
    }


    protected virtual void ConfigureLogger(LoggerConfiguration loggerConfiguration, IConfiguration configuration)
    {
    }

    protected virtual void SetupConfiguration(ConfigurationBuilder configurationBuilder)
    {
    }
}