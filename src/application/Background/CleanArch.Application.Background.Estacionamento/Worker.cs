using CleanArch.Application.Background.Estacionamento.Utils;
using CleanArch.Core.Domain.Entities;
using CleanArch.Core.Domain.Interfaces.Repositories;
using CleanArch.Core.Services.Request.Veiculos;
using CleanArch.Infra.RedisCache;

namespace CleanArch.Application.Background.Estacionamento
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly CachingHelper _cache;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider,
            CachingHelper caching)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;

            _cache = caching;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using IServiceScope scope = _serviceProvider.CreateScope();

                var empresaRepository = scope.ServiceProvider.GetRequiredService<IEmpresaRepository>();
                var veiculoRepository = scope.ServiceProvider.GetRequiredService<IVeiculoRepository>();
                var unifOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();


                foreach (var empresa in await empresaRepository.GetAsync())
                {
                    var key = $"Estacionamento-{empresa.Id}";
                    var records = await _cache.GetRecordAsync<List<VeiculosCadastroRequest>>(key);

                    if (records is not null)
                    {
                        foreach (var record in records)
                        {
                            var veiculoAdicionado = await veiculoRepository.FilterAsync(DateTime.Now.Date, DateTime.Now.Date, record.Placa);

                            if (!veiculoAdicionado)
                            {
                                VeiculosEntity entity = new(record.Marca,
                                    record.Modelo, record.Cor, record.Placa,
                                    record.Tipo, record.EmpresaId);

                                await veiculoRepository.AddASync(entity);
                            }
                        }
                        await unifOfWork.CommitAsync(stoppingToken);
                    }
                }
                await Schedule.RunAsync("0 19 * * 1-5", TimeZoneInfo.Local, stoppingToken);
            }
        }
    }
}