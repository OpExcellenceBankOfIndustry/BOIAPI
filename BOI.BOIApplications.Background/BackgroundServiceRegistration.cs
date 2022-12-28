using BOI.BOIApplications.Application.Contracts.Background;
using BOI.BOIApplications.Background.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BOI.BOIApplications.Background
{
    public static class BackgroundServiceRegistration
    {
        public static IServiceCollection AddBackgroundServices(this IServiceCollection services)
        {
            services.AddScoped<IBackgroundService, BackgroundService>();
            return services;
        }
    }
}
