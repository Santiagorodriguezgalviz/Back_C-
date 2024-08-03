
using Data.Implementations;
using Data.Interfaces;
using Entity.Model.Contexts;
using Microsoft.EntityFrameworkCore;
using Data.Implements;
using Bunnisses.Security.Implemetations;
using Bunnisses.Security.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContexts>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBDefaultConnection")));


// Registra IPersonaData y su implementaci�n
builder.Services.AddScoped<IPersonData, PersonData>();

// Registra IPersonasBusiness y su implementaci�n
builder.Services.AddScoped<IPersonBussines, PersonBusiness>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
