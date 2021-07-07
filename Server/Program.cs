using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prometheus;

var randomizedCounter = Metrics.CreateCounter("random_count", "How many times number (0 - 9) occured from calling Random.Next", "number");
Random random = new ();

var host = Host.CreateDefaultBuilder(args);

host.ConfigureWebHostDefaults(host =>
{
    host.Configure(builder =>
    {
        builder.UseRouting();
        builder.Use(async (ctx, next) =>
        {
            randomizedCounter.WithLabels($"{random.Next(10)}").Inc();
            await next();
        });
        builder.UseEndpoints(endpoints => endpoints.MapMetrics());
    });
});

await host.Build().RunAsync();
