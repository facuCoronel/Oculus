using AccesoDatos.Builder.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Builder
{
    public class RespuestaBuilder<T> : IRespuestaBuilder<T>
    {

        public bool Error { get; set; }
        public string? Mensaje { get; set; }
        public List<T>? Data { get; set; }

        public RespuestaBuilder<T> ErrorMensaje(bool error, string mensaje)
        {
            this.Error = error;
            this.Mensaje = mensaje;

            return this;

        }

        public RespuestaBuilder<T> ErrorMensajeData(bool error, string mensaje, List<T> data)
        {
            this.Data = data;
            this.Error = error;
            this.Mensaje = mensaje;

            return this;
        }


        public RespuestaApi<T> build()
        {
            return new RespuestaApi<T>(this.Data, this.Error, this.Mensaje);
        }


    }
}
