using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Yahoo.Variacao.Ativo
{
    public abstract class RepositorioBase
    {
        private readonly string connectionString;
        public RepositorioBase(IConfiguration configuration)
        {
            connectionString = configuration["Ativos:ConnectionString"];
        }

        public IDbConnection ObterConexao()
        {
            IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
