using Microsoft.Extensions.Configuration;

namespace WebAPI_AlunosVS.Library.Extensions
{
    public class Connection
    {
        public readonly IConfiguration _Configuration;

        public Connection(IConfiguration Configuration)
        {
            _Configuration = Configuration;
        }
        
        public string GetConnection()
        {
            var connection = _Configuration.GetConnectionString("dbConnection");

            return connection;
        }
    }
}