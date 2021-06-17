using Exemplo.ServicoNetCore.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Exemplo.ServicoNetCore.Workers
{
    class ExemploWorker : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ExemploWorker> _logger;

        private readonly Regex _regexDigitsOnly = new Regex(@"[^\d]");
        private bool _fullLogMode = false;

        public ExemploWorker(
           IServiceScopeFactory serviceScopeFactory,
           IConfiguration configuration,
           ILogger<ExemploWorker> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _configuration = configuration;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        { 
            //executa Aqui
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _serviceScopeFactory.CreateScope();
                    var _context = scope.ServiceProvider
                        .GetRequiredService(typeof(PublicContext)) as PublicContext;
                    // loop
                }
                catch (Exception ex)
                {
                    _logger.Log(LogLevel.Critical, ex.ToString());
                }
            }
        }

    }
}
