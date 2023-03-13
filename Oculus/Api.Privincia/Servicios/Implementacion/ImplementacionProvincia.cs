using AccesoDatos;
using AccesoDatos.Builder.Interfaz;
using Api.Provincia.Servicios.Interfaz;
using Dapper;
using Provincia;
using System.Data.SqlClient;

namespace Api.Provincia.Servicios.Implementacion
{
    public class ImplementacionProvincia : IServicioProvincia
    {
        ConexionBD _conn;
        IRespuestaBuilder<Provincias> _rta;
        public ImplementacionProvincia(ConexionBD conn, IRespuestaBuilder<Provincias> rta)
        {
            _conn = conn;
            _rta = rta;
        }

        public async Task<RespuestaApi<Provincias>> Get()
        {
            string query = "select * from Provincia";

            using(var bd = _conn.ConectarBd())
            {
   
                var lProvincia = (await bd.QueryAsync<Provincias>(query)).ToList();

                try
                {
                    if (lProvincia.Count > 0)
                    { 
                        return _rta.ErrorMensajeData(false, "Se consulto correctamente", lProvincia).build();
                    }
                    else
                    {

                        return _rta.ErrorMensajeData(false, "No se encontro ninguna provincia", lProvincia).build();
                    }
                }catch (Exception ex)
                {
                    return _rta.ErrorMensaje(true, $"se produjo la siguiente excepcion {ex}").build();
                }

    
                

            }


        }

        public async Task<RespuestaApi<Provincias>> Save(Provincias NombreProvincia)
        {
            string query = @"insert into Provincia values (@nombre)";

            using (var bd = _conn.ConectarBd())
            {
                bd.Open();
                using(var trans = bd.BeginTransaction())
                {
                    try
                    {
                        var filasAfectadas = await bd.ExecuteAsync(query, new { nombre = NombreProvincia.Provincia }, trans);
                        if (filasAfectadas != 0)
                        {
                            trans.Commit();
                            return _rta.ErrorMensaje(false, "Se inserto correctamente").build();

                        }
                        else
                        {
                            trans.Rollback();
                            return _rta.ErrorMensaje(false, "no se inserto").build();
                        }


                    }
                    catch (Exception ex)
                    {
                        return _rta.ErrorMensaje(false, $"se produjo la siguiente excepcion {ex}").build();

                    }
                }
            }

            
        }
    }
}
