using Microsoft.Extensions.Configuration;

namespace DapperDemo.Configuration
{
    public class DapperConfig
    {
        public string ConnectionString;

        public DapperConfig(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("defaultConnection");
        }
    }
}
