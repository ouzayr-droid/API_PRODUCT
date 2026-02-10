using API_PRODUCT.Application.Services;
using API_PRODUCT.Infrastructure;
using API_PRODUCT.Infrastructure.Repositories;
using API_PRODUCT.Domain.Interfaces;
using API_PRODUCT.Application.Interfaces;

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
// Services Application
// --------------------
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, InMemoryOrderRepository>();

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

app.MapControllers();

app.Run();