using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class ConexionBD
    {
        private readonly IConfiguration _configuration;
        private readonly string? _stringConnection;

        public ConexionBD(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringConnection = _configuration.GetConnectionString("SqlConnection");
        }

        public IDbConnection ConectarBd() => new SqlConnection(_stringConnection);
    }
}