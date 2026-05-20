using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VctFantasy.Domain.Context;
using VctFantasy.Domain.Services;
using VctFantasy.Domain.UseCases;
using VctFantasy.Domain.Util;
using VctFantasy.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Configuration.AddEnvironmentVariables();

builder.Services.Configure<AppSettings>(options => builder.Configuration.GetSection("AppSettings").Bind(options));

builder.Services.AddSingleton<AppSettings>();

// Add services to the container.
builder.Services.AddTransient<TokenService>();
builder.Services.AddTransient<PasswordHasherService>();

builder.Services.AddTransient<UserUseCase>();
builder.Services.AddTransient<TeamUseCase>();
builder.Services.AddTransient<AuthenticationUseCase>();
builder.Services.AddTransient<OrganizationUseCase>();
builder.Services.AddTransient<PlayerUseCase>();


builder.Services.AddControllers();
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
