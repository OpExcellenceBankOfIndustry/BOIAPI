
using BOI.BOIApplications.Application.Contracts.MicrosoftIdentity.JWT;
using BOI.BOIApplications.Application.Contracts.MicrosoftIdentity.UserAccess;
using BOI.BOIApplications.Application.Contracts.MicrosoftIdentity.UserManager;
using BOI.BOIApplications.Application.Model.ConfigurationModels;
using BOI.BOIApplications.Domain.Entities;
//using BOI.BOIApplications.IdentityManagement.Interface;
using BOI.BOIApplications.IdentityManagement.Services;
using BOI.BOIApplications.Persistence;
//using BOI.BOIApplications.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.IdentityManagement
{
    public static class IdentityManagementServiceRegistration
    {
        public static IServiceCollection AddIdentityManagementServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddDefaultIdentity<UserDetail>().AddRoles<UserRole>().AddEntityFrameworkStores<BOIDbContext>();
            services.AddDbContext<BOIDbContext>();
            services.AddDefaultIdentity<UserDetail>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<UserRole>().AddEntityFrameworkStores<BOIDbContext>();

            services.AddScoped<IUserAccess, UserAccess>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.Configure<JwtSettings>(configuration.GetSection("JWT"));


            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options => {
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuerSigningKey = true,
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:Secret"])),
            //            ValidateIssuer = false,
            //            ValidateAudience = false
            //        };
            //    });
            // Adding Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer
            .AddJwtBearer(options =>
            {
                //options.SaveToken = true;
               // options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:Secret"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
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
                options.User.RequireUniqueEmail = true;
            });
            return services;
        }
    }
}
