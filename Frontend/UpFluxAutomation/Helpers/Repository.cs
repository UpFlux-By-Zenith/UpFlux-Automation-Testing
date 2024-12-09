/*using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace UpFluxAutomation.Helpers
{
    public class Repository
    {
        private readonly IConfiguration _configuration;

        public Repository()
        {
            // Use ConfigurationBuilder to load settings from appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Make sure the directory path is correct
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();
        }

        public EngineerModel GetEngineerData()
        {
            var engineerEmail = _configuration["EngineerEmail"];
            var engineerToken = _configuration["EngineerToken"];

            if (string.IsNullOrEmpty(engineerEmail))
                throw new ConfigurationErrorsException("EngineerEmail is not configured.");

            if (string.IsNullOrEmpty(engineerToken))
                throw new ConfigurationErrorsException("EngineerToken is not configured.");

            return new EngineerModel
            {
                Email = engineerEmail,
                EngineerToken = engineerToken
            };
        }
    }
}
*/