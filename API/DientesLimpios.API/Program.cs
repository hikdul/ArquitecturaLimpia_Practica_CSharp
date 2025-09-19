using DientesLimpios.Aplicacion;
using DientesLimpios.Persistencia;
using DientesLimpios.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//!: my own services
builder.Services.AgregarServiciosDeApliacion();
builder.Services.AgregarServiciosDePersistencia();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseManejadorDeExcepciones();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
