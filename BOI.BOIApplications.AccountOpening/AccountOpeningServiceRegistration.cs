using BOI.BOIApplications.AccountOpening.Services;
using BOI.BOIApplications.AccountOpening.Services.AccountOpening;
using BOI.BOIApplications.AccountOpening.Services.MicroCreditLoan;
using BOI.BOIApplications.AccountOpening.Services.RubikonBonitaIntegration;
using BOI.BOIApplications.AccountOpening.Services.ThirdPartyAPI;
using BOI.BOIApplications.Application.Contracts.AccountOpening;
using BOI.BOIApplications.Application.Contracts.MicroCreditLoan;
using BOI.BOIApplications.Application.Contracts.RubikonBonitaIntegrationAPI;
using BOI.BOIApplications.Application.Contracts.ThirdPartyAPI;
using BOI.BOIApplications.Domain.Entities.ThirdPartyAPI;
using BOI.BOIApplications.Persistence;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.AccountOpening
{
    public static class AccountOpeningServiceRegistration
    {
        public static IServiceCollection AddAccountOpeningServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddDbContext<BOIDbContext>();

            services.AddScoped<IAccountOpeningRepository, AccountOpeningRepository>();
            services.AddScoped<IAccountOpeningGetRepository, AccountOpeningGetRepository>();
            services.AddScoped<IAODropDownListRepository, AODropDownListRepository>();
            services.AddScoped<IMCDropDownListRepository, MCDropDownListRepository>();
            services.AddScoped<IThirdPartyAPIRepository, ThirdPartyAPIRepository>();
            services.AddScoped<IRubikonBonitaRepository, RubikonBonitaRepository>();
            services.AddScoped<IRestClient, RestClient>();
            //services.AddOptions();
            //services.Configure<ThirdPartyAPISettings>(configuration.GetSection("ThirdPartyAPISettings"));

            return services;
        }

    }
}
