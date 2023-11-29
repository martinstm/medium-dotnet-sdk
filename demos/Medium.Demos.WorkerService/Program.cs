using Medium.Client.DependencyResolver;
using Medium.Demos.WorkerService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;
using System;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddMediumClient()
        .WithRetryPolicy(m =>
        {
            var delay = Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), 2);
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(delay);
        });
    })
    .Build();

await host.RunAsync();
