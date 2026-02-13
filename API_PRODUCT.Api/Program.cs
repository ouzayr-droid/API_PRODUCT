using API_PRODUCT.Application.Services;
using API_PRODUCT.Infrastructure;
using API_PRODUCT.Infrastructure.Repositories;
using API_PRODUCT.Domain.Interfaces;
using API_PRODUCT.Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// --------------------
// Configuration de l'Infrastructure
// --------------------
builder.Services.AddInfrastructure(
    builder.Configuration.GetConnectionString("DefaultConnection"));

// --------------------
// Auth
// --------------------
var key = builder.Configuration["Jwt:Key"];
var issuer = builder.Configuration["Jwt:Issuer"];
var audience = builder.Configuration["Jwt:Audience"];

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
        };
    });


// --------------------
// Services Application
// --------------------
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, InMemoryOrderRepository>();

// --------------------
// Auth
// --------------------
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<IUserRepository, InMemoryUserRepository>();

// --------------------
// Contrôleurs et Swagger
// --------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// --------------------
// Middleware
// --------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Auth
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();