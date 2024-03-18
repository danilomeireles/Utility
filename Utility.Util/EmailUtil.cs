using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Utility.Util
{
    public static class EmailUtil
    {       
        public static async Task Send(SenderInfo senderInfo, EmailInfo emailInfo)
        {
            var recipientsString = emailInfo.Recipients.Concat(",");
            using var mailMessage = new MailMessage(senderInfo.EmailAddress, recipientsString);
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = emailInfo.Subject;
            mailMessage.Body = emailInfo.Message;

            using var smtpClient = new SmtpClient();
            smtpClient.Host = senderInfo.SmtpServer;
            smtpClient.Port = senderInfo.SmtpPort;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(senderInfo.EmailAddress, senderInfo.Password);
            ServicePointManager.ServerCertificateValidationCallback = (s, certificate, chain, sslPolicyErrors) => true;
            await smtpClient.SendMailAsync(mailMessage);
        }
    }

    public class SenderInfo
    {
        public string EmailAddress { get; set; } = default!;

        public string Password { get; set; } = default!;

        public string SmtpServer { get; set; } = default!;

        public int SmtpPort { get; set; } = default!;
    }

    public class EmailInfo
    {
        public IEnumerable<string> Recipients { get; set; } = new List<string>();

        public string Subject { get; set; }  = default!;

        public string Message { get; set; }  = default!;
    }
}