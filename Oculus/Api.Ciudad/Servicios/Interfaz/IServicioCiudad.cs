using AccesoDatos;
using Modelo;

namespace Api.Ciudad.Servicios.Interfaz
{
    public interface IServicioCiudad
    {
        Task<RespuestaApi<Ciudades>> get();
        Task<RespuestaApi<Ciudades>> save(Ciudades ciudad);
    }
}
