using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using VctFantasy.Domain.Context;
using VctFantasy.Domain.Dtos.Request;
using VctFantasy.Domain.Interfaces;
using VctFantasy.Domain.Services;
using VctFantasy.Domain.UseCases;
using VctFantasy.Domain.Util;
using VctFantasy.Infrastructure.Interfaces;
using VctFantasy.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<AppSettings>>().Value);

// Add services to the container.
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddTransient<IPasswordHasherService, PasswordHasherService>();

builder.Services.AddTransient<IUserUseCase, UserUseCase>();
builder.Services.AddTransient<ITeamUseCase, TeamUseCase>();
builder.Services.AddTransient<IAuthenticationUseCase, AuthenticationUseCase>();
builder.Services.AddTransient<IOrganizationUseCase, OrganizationUseCase>();
builder.Services.AddTransient<IPlayerUseCase, PlayerUseCase>();


builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["AppSettings:SecretKey"])),
        ValidateIssuer = false,
        ValidateAudience = false
    };
}); ;
builder.Services.AddAuthorization();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<VctFantasyContext>(options =>
    options.UseSqlServer(builder.Configuration["AppSettings:DefaultConnection"]));


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
