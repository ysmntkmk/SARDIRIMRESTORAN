using System.Net.Mail;
using System.Threading.Tasks;

namespace NTierSardırımRes.Common.EmailSender
{
    public class EmailSender
    {
       
        // E-posta gönderme metodunu düzenledik
        public async Task SendEmailAsync(string email, string subject, string body)
        {
            // Gönderici ve alıcı bilgilerini ayarlayalım
            string senderEmail = "yasminhayat89@hotmail.com"; // Gönderici e-posta adresi
            string senderPassword = "YsmnTkmk*10"; // Gönderici e-posta şifresi

            // MailMessage oluşturalım
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(senderEmail, "Sardırım Restorant"); // Gönderen bilgisi
            mailMessage.Subject = subject; // E-posta konusu
            mailMessage.Body = body; // E-posta içeriği
            mailMessage.To.Add(email); // Alıcı e-posta adresi

            // SmtpClient oluşturalım ve e-postayı gönderelim
            using (SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com", 587))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(senderEmail, senderPassword);
                smtpClient.EnableSsl = true;

                // E-postayı gönderelim
                await smtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}


