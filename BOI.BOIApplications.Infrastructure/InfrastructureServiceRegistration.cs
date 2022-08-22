
using BOI.BOIApplications.Application.Contracts.Infrastructure;
using BOI.BOIApplications.Infrastructure.Caching;
using BOI.BOIApplications.Infrastructure.Mail;
using BOI.BOIApplications.Infrastructure.ServerPings;
using BOI.BOIApplications.Infrastructure.Validations;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BOI.BOIApplications.Infrastructure;
public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddScoped<IServerCheck, ServerCheck>();
        services.AddScoped<IEmailService, EmailService>();

        return services;
    }
}
