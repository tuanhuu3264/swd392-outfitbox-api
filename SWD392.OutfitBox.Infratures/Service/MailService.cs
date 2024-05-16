using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Infrastructure.Service
{
    public class MailService
    {
        public async Task SendOTPToMail(string OTP, string email, string username)
        {
            var from = new MailboxAddress(name: "", address: "famsphase@gmail.com");
            var to = new MailboxAddress(name: "", address: email.ToLower());


            var msj = new MimeMessage();
            msj.From.Add(from);
            msj.To.Add(to);
            msj.Subject = "Confirm your account in Fams";
            msj.Body = new TextPart(TextFormat.Html)
            {

                Text = $"<h1>Hi {username}</h1>" 
            };

            var client = new MailKit.Net.Smtp.SmtpClient();

            client.Connect(host: "smtp.gmail.com",
                           port: 465,
                           options: MailKit.Security.SecureSocketOptions.SslOnConnect);



            client.Authenticate("famsphase@gmail.com", "ypxwnqunarqjfmty");

            client.Send(msj);

            client.Disconnect(true);
        }

    }
}
