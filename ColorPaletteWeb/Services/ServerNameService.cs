namespace BoilerDemo.Services
{
    public class ServerNameService 
        : IServerNameService
    {
        private readonly IConfiguration _configuration;

        public ServerNameService(
            IConfiguration configuration
        )
        {
            _configuration = configuration;
        }

        // Gets Server-Name from appsettings.json
        public string GetServerName()
        {
            return _configuration.GetValue<string>( "Server-Name" );
        }

    }
}
