using System.Configuration;

namespace UpFluxAutomation.Utilities
{
    public static class EnvironmentConfig
    {
        public static string BaseUrl => ConfigurationManager.AppSettings["BaseUrl"];
        public static string AdminEmail => ConfigurationManager.AppSettings["AdminEmail"];
        public static string AdminPassword => ConfigurationManager.AppSettings["AdminPassword"];
    }
}