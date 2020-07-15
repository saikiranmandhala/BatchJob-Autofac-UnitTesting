namespace BatchJobInfrastructure
{
    /// <summary>
    /// Author: Saikiran Mandhala
    /// Email: saikiran.mandhala@gmail.com
    /// Date: 15/07/2020
    /// </summary>
    public class EmailHandler : IEmailHandler
    {
        private SmtpSettings _smtpSettings;
        private ILogger _logger;
        public EmailHandler(SmtpSettings smtpSettings, ILogger logger)
        {
            _smtpSettings = smtpSettings;
            _logger = logger;
        }

        public void SendEmail()
        {
            _logger.Log("Step 5: Orders Process success email sent.");

        }
    }
}
