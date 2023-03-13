using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Clientes
    {
        public int id_cliente { get; set; }
        public string nombre { get; set; }
        public int telefono { get; set; }
        public Ciudades Ciudad { get; set; }
        public int id_ciudad { get; set; }
        public Clientes()
        {
            Ciudad = new Ciudades();
        }

        public Clientes( string nombre, int telefono, Ciudades ciudad)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            Ciudad = ciudad;
        }
    }
}
