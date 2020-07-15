namespace BatchJobInfrastructure
{
    /// <summary>
    /// Author: Saikiran Mandhala
    /// Email: saikiran.mandhala@gmail.com
    /// Date: 15/07/2020
    /// </summary>
    public class SmtpSettings
    {
        public SmtpSettings(string from, string port, string domain)
        {
            _from = from;
            _port = port;
            _domain = domain;
        }
        public string _from { get; set; }
        public string _port { get; set; }
        public string _domain { get; set; }
    }
}
