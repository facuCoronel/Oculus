using Provincia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Ciudades
    {
        public int id_ciudad { get; set; }
        public string? Ciudad { get; set; }
        public Provincias provincia { get; set; }

        public Ciudades()
        {
            provincia = new Provincias();
        }
    }
}
