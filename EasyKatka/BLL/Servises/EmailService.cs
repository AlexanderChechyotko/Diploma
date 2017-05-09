using Microsoft.AspNet.Identity;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            var from = "sasha.chechyotko@yandex.ru";
            var pass = "4qz1001hp";

            SmtpClient client = new SmtpClient("smtp.yandex.ru", 25);

            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(from, pass);
            client.EnableSsl = true;

            var mail = new MailMessage(from, message.Destination);
            mail.Subject = message.Subject;
            mail.Body = message.Body;
            mail.IsBodyHtml = true;

            return client.SendMailAsync(mail);
        }
    }
}
