using Medium.Client.DependencyResolver;
using Medium.Demos.WorkerService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddMediumClient();
    })
    .Build();

await host.RunAsync();
