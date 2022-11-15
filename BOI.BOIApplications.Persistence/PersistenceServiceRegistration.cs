using BOI.BOIApplications.Application.Contracts.Legacy.Persistence;
using BOI.BOIApplications.Application.Contracts.Persistence.GeoInformation;
using BOI.BOIApplications.Application.Contracts.Persistence.Influence;
using BOI.BOIApplications.Application.Contracts.Persistence.Mail;
using BOI.BOIApplications.Domain.Entities;
using BOI.BOIApplications.Persistence.Repository;
using BOI.BOIApplications.Persistence.Repository.GeoInformation;
using BOI.BOIApplications.Persistence.Repository.Influence;
using BOI.BOIApplications.Persistence.Repository.Mail;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BOI.BOIApplications.Application.Contracts.Persistence.Identity;
using BOI.BOIApplications.Persistence.Repository.Identity;

namespace BOI.BOIApplications.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceervices(this IServiceCollection services, IConfiguration configuration)
        {
            

            services.AddDbContext<BOIDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BOIApplicationConnectionString")));
            services.AddDbContext<BOI2DbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BOIApplicationConnectionString")));
            services.AddDbContext<BOI3DbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BOIApplicationConnectionString")));

            services.AddIdentityCore<UserDetail>(options =>
            {
                options.User.RequireUniqueEmail = false;
            }).AddEntityFrameworkStores<BOIDbContext>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<ILGARepository, LGARepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IEmailAttachmentRepository, EmailAttachmentRepository>();
            services.AddScoped<IEmailAttachmentRepository, EmailAttachmentRepository>();
            services.AddScoped<IPEPRepository, PEPRepository>();
            services.AddScoped<IFEPRepository, FEPRepository>();
            services.AddScoped<ICorporateWatchListRepository, CorporateWatchListRepository>();
            services.AddScoped<IIndividualWatchListRepository, IndividualWatchListRepository>();
            services.AddScoped<IJWTCredentialRepository, JWTCredentialRepository>();


            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });


            return services;
        }
    }
}
