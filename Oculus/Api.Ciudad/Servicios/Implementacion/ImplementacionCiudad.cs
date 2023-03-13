using AccesoDatos;
using AccesoDatos.Builder.Interfaz;
using Api.Ciudad.Servicios.Interfaz;
using Dapper;
using Modelo;

namespace Api.Ciudad.Servicios.Implementacion
{
    public class ImplementacionCiudad : IServicioCiudad
    {
        ConexionBD _conn;
        IRespuestaBuilder<Ciudades> _rta;
        public ImplementacionCiudad(ConexionBD conn, IRespuestaBuilder<Ciudades> rta)
        {
            _conn = conn;
            _rta = rta;
        }

        public async Task<RespuestaApi<Ciudades>> get()
        {
            using (var bd = _conn.ConectarBd())
            {
                string query = "Select * from Ciudad";


                try
                {
                    var lCiudades = (await bd.QueryAsync<Ciudades>(query)).ToList();


                    if(lCiudades.Count < 0)
                    {
                        
                        return _rta.ErrorMensajeData(false, "se consulto correctamente", lCiudades).build();
                    }
                    else
                    {
                        return _rta.ErrorMensajeData(false, "se no existen los registros", lCiudades).build(); ;
                    }



                }catch(Exception ex)
                {

                    return _rta.ErrorMensaje(true, $"Se produjo la siguiente excepcion {ex}").build();
                }

            }
        }

        public async Task<RespuestaApi<Ciudades>> save(Ciudades ciudad)
        {
            using(var bd = _conn.ConectarBd())
            {
                bd.Open();
                using (var trans = bd.BeginTransaction())
                {
                    string query = @"insert into ciudad values (@nombre,@idProv)";

                    try
                    {
                        var insert = await bd.ExecuteAsync(query, new { nombre = ciudad.Ciudad, idProv = ciudad.provincia.Id_Provincia }, trans);

                        if(insert > 0)
                        {
                            trans.Commit();
                            return _rta.ErrorMensaje(false, "se guardo correctamente").build();
                        }
                        else
                        {

                            trans.Rollback();
                            return _rta.ErrorMensaje(false, "no se pudo insertar").build();

                        }



                    }catch(Exception ex)
                    {
                        trans.Rollback();
                        return _rta.ErrorMensaje(true, $"Se produjo la siguiente excepcion {ex}").build();
                    }

                }
            }
        }
    }
}
