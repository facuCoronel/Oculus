using Modelo;

namespace Api.Cliente.Builder
{
    public class BuilderCliente
    {
        public int id_cliente { get; set; }
        public string? nombre { get; set; }
        public int telefono { get; set; }
        public Ciudades Ciudad { get; set; }

        public BuilderCliente()
        {
            Ciudad = new Ciudades();
        }

        public BuilderCliente BuilderNombreTelefono(string _nombre, int _telefono)
        {
            this.nombre = _nombre;
            this.telefono = _telefono;
            return this;
        }

        public BuilderCliente BuilderCiudad(int id_ciudad)
        {
            this.Ciudad.id_ciudad = id_ciudad;
            return this;
        }


        public Clientes Build()
        {
            return new Clientes(nombre, telefono, Ciudad);
        }

    }
}
