using Learning.Repository.Interfaces;
using Learning.Repository.Repositories;
using Learning.Service.Interfaces;
using Learning.Service.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Learn API",
            Description = "API for Learning the Microsoft Applied Skills Path Develop an ASP.NET Core web app that consumes an API.",
            TermsOfService = new Uri("https://example.com/terms")
        });
    });

builder.Services.TryAddScoped<IPetService, PetService>();
builder.Services.TryAddScoped<IPetRepository, PetRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
