using Microsoft.Extensions.Configuration;

namespace BatchJobInfrastructure
{
    /// <summary>
    /// Author: Saikiran Mandhala
    /// Email: saikiran.mandhala@gmail.com
    /// Date: 15/07/2020
    /// </summary>
    public class AppSettings : IAppSettings
    {
        private IConfigurationRoot _configurationRoot;
        public AppSettings(IConfigurationRoot configurationRoot)
        {
            _configurationRoot = configurationRoot;
        }

        public string ConnectionString
        {
            get
            {
                return _configurationRoot.GetSection("ConnectionString").Value;
            }
        }

    }
}
