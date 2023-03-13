using AccesoDatos;
using AccesoDatos.Builder;
using AccesoDatos.Builder.Interfaz;
using Api.Cliente.Servicios.Implementacion;
using Api.Cliente.Servicios.Interfaz;
using Modelo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



#region Acceso a datos

builder.Services.AddSingleton<ConexionBD>();

#endregion


#region inyeccion de dependencias

builder.Services.AddScoped<IServicioCliente, ImplementacionCliente>();
builder.Services.AddScoped<IRespuestaBuilder<Clientes>, RespuestaBuilder<Clientes>>();

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
