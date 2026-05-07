using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VctFantasy.Domain.Context;
using VctFantasy.Domain.Services;
using VctFantasy.Domain.UseCases;
using VctFantasy.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<TokenService>();
builder.Services.AddTransient<PasswordHasherService>();

builder.Services.AddTransient<RegisterUserUseCase>();
builder.Services.AddTransient<RegisterTeamUseCase>();
builder.Services.AddTransient<AuthenticationUseCase>();

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
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("secretkey")),
        ValidateIssuer = false,
        ValidateAudience = false
    };
}); ;
builder.Services.AddAuthorization();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<VctFantasyContext>(options =>
    options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=VctFantasy;TrustServerCertificate=True;Trusted_Connection=True;"));

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
