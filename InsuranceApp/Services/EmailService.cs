using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace InsuranceApp.Services
{
   
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendConfirmation(string toEmail, string subject, string body)
        {
            var fromEmail = _config["EmailSettings:From"];
            var smtpHost = _config["EmailSettings:Smtp"];
            var smtpPort = int.Parse(_config["EmailSettings:Port"]);
            var smtpUser = _config["EmailSettings:Username"];
            var smtpPass = _config["EmailSettings:Password"];

            var message = new MailMessage(fromEmail, toEmail, subject, body);

            using var client = new SmtpClient(smtpHost, smtpPort)
            {
                Credentials = new NetworkCredential(smtpUser, smtpPass),
                EnableSsl = true
            };
            client.Send(message);
        }
    }
}
