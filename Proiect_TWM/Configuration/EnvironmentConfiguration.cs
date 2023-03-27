
using Microsoft.Extensions.Configuration;

namespace Proiect_TWM.Configuration
{
    public class EnvironmentConfiguration : IEnvironmentConfiguration
    {
        private readonly IConfiguration _configuration;
        public EnvironmentConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetKeys(string parentSection, string keySection)
        {
            var key = _configuration.GetSection(parentSection).GetSection(keySection).Value;
            return key;
        }
    }
}
