using BOI.BOIApplications.Application.Contracts.AccountOpening;
using BOI.BOIApplications.Application.Model.ConfigurationModels;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BOI.BOIApplications.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}