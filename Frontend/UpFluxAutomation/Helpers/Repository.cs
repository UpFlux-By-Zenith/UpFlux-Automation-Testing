using System;
using System.Configuration;
using System.IO;
using System.Text.Json;
using UpFluxAutomation.Models;

namespace UpFluxAutomation.Helpers
{
    public class Repository
    {
        public AdminModel GetAdminData()
        {
            return new AdminModel
            {
                Email = ConfigurationManager.AppSettings["AdminEmail"] ?? throw new ConfigurationErrorsException("AdminEmail is not configured."),
                Password = ConfigurationManager.AppSettings["AdminPassword"] ?? throw new ConfigurationErrorsException("AdminPassword is not configured.")
            };
        }

        public EngineerModel GetEngineerData(string tokenFilePath)
        {
            if (!File.Exists(tokenFilePath))
            {
                throw new FileNotFoundException($"Token file not found: {tokenFilePath}");
            }

            var tokenData = File.ReadAllText(tokenFilePath);
            var engineerToken = JsonSerializer.Deserialize<string>(tokenData);

            return new EngineerModel
            {
                Email = ConfigurationManager.AppSettings["EngineerEmail"] ?? throw new ConfigurationErrorsException("EngineerEmail is not configured."),
                EngineerToken = engineerToken ?? throw new Exception("EngineerToken is missing in the JSON file.")
            };
        }
    }
}
