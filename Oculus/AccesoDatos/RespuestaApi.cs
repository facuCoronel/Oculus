using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{

    public class RespuestaBase
    {
        public bool Error { get; set; }
        public string? Mensaje { get; set; }

        public RespuestaBase(bool error, string? mensaje)
        {
            Error = error;
            Mensaje = mensaje;
        }
    }
    public class RespuestaApi<T> : RespuestaBase
    {
        public List<T>? Data { get; set; }

        public RespuestaApi(List<T>? data, bool error, string mensaje) : base(error, mensaje)
        {
            Data = data;
            Error = error;
            Mensaje = mensaje;
        }
    }
}
