using BOI.BOIApplications.Application;
using BOI.BOIApplications.Application.Contracts.MicrosoftIdentity.JWT;
using BOI.BOIApplications.Application.Contracts.MicrosoftIdentity.UserAccess;
using BOI.BOIApplications.Application.Contracts.MicrosoftIdentity.UserManager;
using BOI.BOIApplications.Application.Model.ConfigurationModels;
using BOI.BOIApplications.IdentityManagement;
using BOI.BOIApplications.IdentityManagement.Services;
using BOI.BOIApplications.Infrastructure;
using BOI.BOIApplications.Infrastructure.Logging;
using BOI.BOIApplications.Legacy.Persistence;
using BOI.BOIApplications.Persistence;
using BOI.BOIApplications.WorkerService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        
        IConfiguration configuration = hostContext.Configuration;
        services.AddPersistenceLegacyServices(configuration);
        services.AddPersistenceervices(configuration);
        services.AddApplicationServices();
        services.AddInfrastructureServices();
        services.AddIdentityManagementServices(configuration);
        services.AddHostedService<Worker>();
        services.Configure<ServiceConfigurationSettings>(configuration.GetSection("ServiceConfigurationSettings"));
        services.Configure<EmailConfigurationSettings>(configuration.GetSection("EmailSettings"));

    })
    .UseSerilog(Logging.ConfigureLogger)
    .UseWindowsService()
    .Build();

await host.RunAsync();
