using BOI.BOIApplications.Application.Contracts.Legacy.Persistence;
using BOI.BOIApplications.Application.Model.ConfigurationModels;
using BOI.BOIApplications.Legacy.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BOI.BOIApplications.Legacy.Persistence
{
    public static class PersistenceLegacyServiceRegistration
    {
        public static IServiceCollection AddPersistenceLegacyServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Bonita_bdmContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("bonitaConnString")),ServiceLifetime.Singleton);

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
