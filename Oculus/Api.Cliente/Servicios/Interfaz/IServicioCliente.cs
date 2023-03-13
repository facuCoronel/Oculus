using AccesoDatos;
using Modelo;

namespace Api.Cliente.Servicios.Interfaz
{
    public interface IServicioCliente
    {
        Task<RespuestaApi<Clientes>> GetClientes();
        Task<RespuestaApi<Clientes>> InsertarCliente(string nombre, int tel, int idCiudad);
        Task<RespuestaApi<Clientes>> Update(int idCliente, string nombre, int telefono, int idCiudad);

    }
}
