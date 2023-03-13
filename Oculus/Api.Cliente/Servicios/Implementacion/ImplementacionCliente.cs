using AccesoDatos;
using AccesoDatos.Builder.Interfaz;
using Api.Cliente.Servicios.Interfaz;
using Dapper;
using Modelo;

namespace Api.Cliente.Servicios.Implementacion
{
    public class ImplementacionCliente : IServicioCliente
    {
        ConexionBD _conn;
        IRespuestaBuilder<Clientes> _rta;
        public ImplementacionCliente(ConexionBD conn, IRespuestaBuilder<Clientes> rta)
        {
            _conn = conn;
            _rta = rta;
        }




        public async Task<RespuestaApi<Clientes>> GetClientes()
        {
            string query = "Select * from Cliente";

            using (var bd = _conn.ConectarBd())
            {

                try
                {
                    var result = (await bd.QueryAsync<Clientes>(query)).ToList<Clientes>();

                    if (result.Count > 0)
                    {
                        return _rta.ErrorMensajeData(false, "se consulto correctamente", result).build();
                    }
                    else
                    {
                        return _rta.ErrorMensaje(false, "No se encontro ningun registro").build();
                    }

                }
                catch (Exception ex)
                {
                    return _rta.ErrorMensaje(true, $"se produjo la siguiente excepcion {ex}").build();
                }
            }
        }

        public async Task<RespuestaApi<Clientes>> InsertarCliente(string nombre, int tel, int idCiudad)
        {
            string query = @"insert into Cliente values(@nombre, @telefono, @idciudad)";

            using(var bd = _conn.ConectarBd())
            {
                bd.Open();
                using (var trans = bd.BeginTransaction())
                {
                    var result = await bd.ExecuteAsync(query, new { nombre = nombre, telefono = tel, idciudad = idCiudad }, trans);
                    try
                    {
                        if (!result.Equals(0))
                        {
                            trans.Commit();
                            return _rta.ErrorMensaje(false, "se inserto correctamente").build();
                        }
                        else { trans.Commit(); return _rta.ErrorMensaje(false, "No se afecto ninguna fila").build(); };
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        return _rta.ErrorMensaje(true, $"se produjo la siguiente excepcion: {ex}").build();
                    }
                }
            }
        }



        public async Task<RespuestaApi<Clientes>> Update(int idCliente, String nombre, int telefono, int idCiudad)
        {
            string query = @"update cliente set";
            string where = @" where id_cliente = @idCliente";

            using (var bd = _conn.ConectarBd())
            {
                try
                {
                    if (idCliente.Equals(null) || idCliente.Equals(0))
                    {
                        return _rta.ErrorMensaje(false, "no se mando como parametro el id").build();
                    }
                    if (nombre != null)
                    {
                        query += @" nombre = @nombre ";
                        if (!telefono.Equals(0))
                        {
                            query += " , telefono = @telefono";
                            if (!idCiudad.Equals(0))
                            {
                                query += @" , id_ciudad = @idCiudad";
                            }
                        }
                        query += where;
                        var result = await bd.ExecuteAsync(query, new {nombre = nombre, telefono = telefono, idCiudad = idCiudad, idCliente = idCliente});
                        return _rta.ErrorMensaje(false, "se inserto correctamente").build();
                    }
                    else if (!telefono.Equals(0) && nombre == null && idCiudad.Equals(0))
                    {

                        query += @" telefono = @telefono ";
                        query += where;

                        var result = await bd.ExecuteAsync(query, new { idCliente = idCliente, idCiudad = idCiudad, telefono = telefono });
                        return _rta.ErrorMensaje(false, "se inserto correctamente").build();
                    }
                    else if (!idCiudad.Equals(0) && nombre == null && telefono.Equals(0))
                    {
                        query += " id_ciudad = @idCiudad ";
                        query += where;

                        var result = await bd.ExecuteAsync(query, new { idCliente = idCliente, idCiudad = idCiudad});
                        return _rta.ErrorMensaje(false, "se inserto correctamente").build();
                    }

                    return _rta.ErrorMensaje(false, "no se aniaderon los parametros correctamente").build();


                }
                catch (Exception ex)
                {
                    return _rta.ErrorMensaje(false, $"se produjo la siguiente excepcion {ex}").build();
                }

              
            }
        }
    }
}
