using CleanArch.Application.Background.Estacionamento;
using CleanArch.Infra.RedisCache;
using CleanArch.Infra.SQLServer;
using CleanArch.Core.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        #region redis configuration
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = Environment.GetEnvironmentVariable("REDIS_CONNECTION");
            options.InstanceName = "Estacionamento";
        });
        #endregion

        services.AddSingleton<CachingHelper>();
        services.AddSqlServerModule(Environment.GetEnvironmentVariable("CONNECTION_STRING_SQL_SERVER"));
        services.AddRepositoryModule();
        services.AddUseCasesModules();

        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
