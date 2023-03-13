using AccesoDatos;
using AccesoDatos.Builder;
using AccesoDatos.Builder.Interfaz;
using Api.Ciudad.Servicios.Implementacion;
using Api.Ciudad.Servicios.Interfaz;
using Modelo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region AccesoDatos
//acceso datos
builder.Services.AddSingleton<ConexionBD>();
#endregion

#region Inyeccion de dependencias
//Inyeccion de dependencias
builder.Services.AddScoped<IServicioCiudad, ImplementacionCiudad>();
builder.Services.AddScoped<IRespuestaBuilder<Ciudades>, RespuestaBuilder<Ciudades>>();
#endregion


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
