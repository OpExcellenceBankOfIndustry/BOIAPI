
using BOI.BOIApplications.Application.Features.WorkerService.CheckBonitaAvaliablity;
using BOI.BOIApplications.Application.Features.WorkerService.CreateEmployee;
using BOI.BOIApplications.Application.Features.WorkerService.SendEnqueuedEmail;
using BOI.BOIApplications.Application.Model.ConfigurationModels;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BOI.BOIApplications.WorkerService;
public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IMediator _mediator;
    private readonly IServiceProvider _serviceProvider;
    private readonly ServiceConfigurationSettings _serviceConfigurtionSettings;

    public Worker(ILogger<Worker> logger, IMediator mediator,
        IOptions<ServiceConfigurationSettings> serviceConfigurtionSettings, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _mediator = mediator;
        _serviceProvider = serviceProvider;
        _serviceConfigurtionSettings = serviceConfigurtionSettings.Value;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    // Read new employee files created by HR and insert into bonita Database
                    await scope.ServiceProvider.GetRequiredService<IMediator>().Send(new CreateEmployeeCommand(), stoppingToken);

                    if (_serviceConfigurtionSettings.ActivateEnqueueEmail)
                    {
                        // Read Enqueued email and send 
                        await scope.ServiceProvider.GetRequiredService<IMediator>().Send(new SendEnqueuedEmailCommand(), stoppingToken);
                    }

                    // Send alerts when bonita website is down
                    await scope.ServiceProvider.GetRequiredService<IMediator>().Send(new CheckBonitaAvaliablityCommand(), stoppingToken);
                }
                await Task.Delay(60 * _serviceConfigurtionSettings.RunningPeriod, stoppingToken);
            }
            catch (OperationCanceledException)
            {
                return;
            }
        }
    }
}

