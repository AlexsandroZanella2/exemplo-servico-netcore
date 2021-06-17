using Exemplo.ServicoNetCore.DataAccess;
using Exemplo.ServicoNetCore.Workers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace Exemplo.ServicoNetCore
{
    public class Program
    {
        public static void Main(string[] args) =>
            CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureAppConfiguration(config =>
                {
                    config.AddJsonFile("appsettings.json", true);
                })
                .ConfigureLogging((hostingContext, builder) =>
                {
                    var logLevel = hostingContext.Configuration.GetValue(typeof(string), "LogLevel");
                    builder.AddFile(@"C:\log-{Date}.txt", Enum.Parse<LogLevel>(logLevel.ToString()));
                })
                .ConfigureServices((hostContext, services) =>
                {                   
                    services.AddDbContext<PublicContext>(x =>
                        x.UseNpgsql(hostContext.Configuration.GetConnectionString(nameof(PublicContext))));

                    services.AddHostedService<ExemploWorker>(); // Banco Local -> Banco Oracle
                });
    }
}
