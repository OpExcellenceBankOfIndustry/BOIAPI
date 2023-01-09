using AutoMapper;
using BOI.BOIApplications.AccountOpening.Interfaces;
using BOI.BOIApplications.AccountOpening.Services;
using BOI.BOIApplications.AccountOpening.Services.ThirdPartyAPI;
using BOI.BOIApplications.Application.Contracts.ThirdPartyAPI;
using BOI.BOIApplications.Application.Profiles.API.AccountOpening;
using BOI.BOIApplications.Domain.Entities.Settings;
using BOI.BOIApplications.Domain.Entities.ThirdPartyAPI;
using BOI.BOIApplications.Persistence;
using BOI.BOIApplications.Persistence.InterfaceRepository;
using BOI.BOIApplications.Persistence.ServiceRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RestSharp;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddDbContext<BOIDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("BOIApplicationConnectionString")));
builder.Services.AddDbContext<BOI3DbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BOIApplicationConnectionString")));
builder.Services.AddDistributedMemoryCache();
builder.Services.AddScoped<IRestClient, RestClient>();


//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AccountOpeningMappingProfiles());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
//builder.Services.Configure<AppSettings>(configuration.GetSection("ThirdPartyAPISettings"));
builder.Services.AddOptions();
builder.Services.Configure<ThirdPartyAPISettings>(configuration.GetSection("ThirdPartyAPISettings"));
builder.Services.Configure<JWTSettings>(configuration.GetSection("JWT"));
builder.Services.AddScoped<ITokenHandler, BOI.BOIApplications.AccountOpening.Services.TokenHandler>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IThirdPartyAPIRepository, ThirdPartyAPIRepository>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyOrigin", builder => builder.AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());
    //.AllowCredentials()

});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//Swagger Authentication Settings
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "BOI.SecureApplication.API", Version = "v1" });
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {securityScheme, new string[] {} }
    });
    options.DescribeAllParametersInCamelCase();
});

//JWT Settings
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    });
//Session Settings
builder.Services.AddSession(options =>
{
    // Set a short timeout for easy testing.
    options.IdleTimeout = TimeSpan.FromMinutes(600);
    options.Cookie.HttpOnly = true;
    // Make the session cookie essential
    options.Cookie.IsEssential = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowMyOrigin");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
