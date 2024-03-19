using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NTierSardırımRes.Common
{
    public class EmailSender
    {
        public static void SendEmail(string email, string subject, string body)
        {
            //MailMessage
            MailMessage sender = new MailMessage();
            sender.From = new MailAddress("sardirimrestoran@outlook.com", "Sardırım Project");
            sender.Subject = subject;
            sender.Body = body;
            sender.To.Add(email);

            //SmtpClient
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential("sardirimrestoran@outlook.com", "Sardirim");
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Host = "smtp-mail.outlook.com";
            smtpClient.Send(sender);

        }
    }
}
