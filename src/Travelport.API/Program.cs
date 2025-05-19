using Microsoft.EntityFrameworkCore;
using Travelport.Application.Interfaces;
using Travelport.Application.Services;
using Travelport.Infrastructure.DbContext;
using Travelport.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// EF Core InMemory
builder.Services.AddDbContext<RegistrationDbContext>(options =>
    options.UseInMemoryDatabase("RegistrationDb"));

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<PersonService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();      
    app.UseSwaggerUI();    
}

app.MapControllers();
app.Run();