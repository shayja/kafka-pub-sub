using Microsoft.Extensions.Hosting;
using ApacheKafkaConsumer.Common.Extensions;
using Microsoft.Extensions.Configuration;

using var host = CreateHostBuilder(args).Build();
await host.RunAsync();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
        services.ConfigureServices())
   .ConfigureHostConfiguration(hostConfig =>
    {
        hostConfig.SetBasePath(Directory.GetCurrentDirectory());
        hostConfig.AddJsonFile("appsettings.json", optional: true);
        //hostConfig.AddEnvironmentVariables(prefix: "PREFIX_");
        //hostConfig.AddCommandLine(args);
    });