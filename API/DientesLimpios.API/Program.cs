using DientesLimpios.Aplicacion;
using DientesLimpios.Persistencia;
using DientesLimpios.API.Middleware;
using DientesLimpios.Infraestructura;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//!: my own services
builder.Services.AgregarServiciosDeApliacion();
builder.Services.AgregarServiciosDePersistencia();
builder.Services.AgregarServiciosDeInfraestructura();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseManejadorDeExcepcionesMiddleware();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
