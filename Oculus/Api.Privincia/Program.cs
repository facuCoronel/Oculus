using AccesoDatos;
using AccesoDatos.Builder;
using AccesoDatos.Builder.Interfaz;
using Api.Provincia.Servicios.Implementacion;
using Api.Provincia.Servicios.Interfaz;
using Provincia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region AccesoDatos
//AccesoDatos
builder.Services.AddSingleton<ConexionBD>();
#endregion

#region Inyeccion
builder.Services.AddScoped<IServicioProvincia, ImplementacionProvincia>();
builder.Services.AddScoped<IRespuestaBuilder<Provincias>, RespuestaBuilder<Provincias>>();
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
