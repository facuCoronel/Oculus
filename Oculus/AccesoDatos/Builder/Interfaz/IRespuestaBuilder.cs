using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Builder.Interfaz
{
    public interface IRespuestaBuilder<T>
    {
        public RespuestaBuilder<T> ErrorMensaje(bool error, string mensaje);
        public RespuestaBuilder<T> ErrorMensajeData(bool error, string mensaje, List<T> data);
        public RespuestaApi<T> build();
    }
}
