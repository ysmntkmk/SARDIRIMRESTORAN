using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace NTierSardırımRes.Common.EmailSender
{
    public class EmailSender
    {

        // E-posta gönderme metodunu düzenledik
        public static void SendEmail(string email, string subject, string body)
        {
            //MailMessage
            MailMessage sender = new MailMessage();
            sender.From = new MailAddress("sardirimrestoran@outlook.com", "Sardirim Restoran");
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


