using AccesoDatos;
using Provincia;

namespace Api.Provincia.Servicios.Interfaz
{
    public interface IServicioProvincia
    {
        Task<RespuestaApi<Provincias>> Save(Provincias NombreProvincia);
        Task<RespuestaApi<Provincias>> Get();
    }
}
