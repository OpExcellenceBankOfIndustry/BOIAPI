using AutoMapper;
using BOI.BOIApplications.AccountOpening;
using BOI.BOIApplications.API.Middleware;
using BOI.BOIApplications.Application;
using BOI.BOIApplications.Application.Profiles.API.RubikonBonitaIntegration;
using BOI.BOIApplications.Domain.Entities.ThirdPartyAPI;
using BOI.BOIApplications.IdentityManagement;
using BOI.BOIApplications.Infrastructure;
using BOI.BOIApplications.Infrastructure.Logging;
using BOI.BOIApplications.Legacy.Persistence;
using BOI.BOIApplications.Persistence;
using BOI.BOIApplications.Persistence.Repository;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

//builder.Host.UseSerilog(Logging.ConfigureLogger);



Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File($"{AppDomain.CurrentDomain.BaseDirectory}logs\\AccountOpeningAPI.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog(Log.Logger);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices(configuration);
builder.Services.AddPersistenceLegacyServices(configuration);
builder.Services.AddDistributedMemoryCache();
builder.Services.AddIdentityManagementServices(configuration);
builder.Services.AddAccountOpeningServices(configuration);
builder.Services.Configure<JWTSettings>(configuration.GetSection("JWTS"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyOrigin", builder => builder.AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());
    //.AllowCredentials()

});

builder.Services.AddOptions();
builder.Services.Configure<ThirdPartyAPISettings>(configuration.GetSection("ThirdPartyAPISettings"));
builder.Services.Configure<RubikonBonitaIntegrationAPISettings>(configuration.GetSection("RubikonBonitaIntegrationAPISettings"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDistributedMemoryCache();

AddSwagger(builder.Services);


#region SwaggerImplementation
static void AddSwagger(IServiceCollection services)
{
    services.AddSwaggerGen(c =>
    {
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
               new OpenApiSecurityScheme
               {
                 Reference = new OpenApiReference
                 {
                     Type = ReferenceType.SecurityScheme,
                     Id = "Bearer"
                 },
                   Scheme = "oauth2",
                   Name = "Bearer",
                   In = ParameterLocation.Header,

               },
                   new List<string>()
            }
        });

        c.SwaggerDoc("v1", new OpenApiInfo { Title = "BOI.BOIApplications.API", Version = "v1" });

        c.EnableAnnotations();
        var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);
        c.IncludeXmlComments(xmlCommentsFullPath);

    });

    services.AddSwaggerGenNewtonsoftSupport();

}
#endregion

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddAutoMapper(typeof(RubikonBonitaIntegrationMappingProfiles));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseSwagger();

app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v1/swagger.json", "BOI.BOIApplications.API v1"));

app.UseHttpsRedirection();

app.UseCustomExceptionHandler();
app.UseCors("AllowMyOrigin");
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers(); 
app.UseStaticFiles();

app.Run();
