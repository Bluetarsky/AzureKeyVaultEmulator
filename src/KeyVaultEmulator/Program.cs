using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Extensions.Logging;
using Serilog.Formatting.Elasticsearch;

namespace AzureKeyVaultEmulator
{
    public class Program
    {
        static readonly LoggerProviderCollection Providers = new LoggerProviderCollection();

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog((builderContext, config) =>
                {
                    config
                        .MinimumLevel.Information()
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                        .Enrich.FromLogContext()
                        .Enrich.WithProcessId()
                        .Enrich.WithProcessName()
                        .Enrich.WithThreadId()
                        .Enrich.WithThreadName()
                        .Enrich.WithUserName()
                        .WriteTo.Providers(Providers)
                        .WriteTo.Console(new ElasticsearchJsonFormatter());
                });
    }
}
