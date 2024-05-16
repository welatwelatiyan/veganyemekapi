using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;
using VY.Business.Layer.Auth.Abstarct;

namespace VY.Business.Layer.Auth.Concreate
{
    public class MailService : IMailService
    {
        private IConfiguration configuration;
        public MailService(IConfiguration configuration)
        {
            this.configuration = configuration;

        }
        public async Task sendMail(string mail, string content, string title)
        {
            MailSettingEntity mailSetting = configuration.GetSection("MailSettings").Get<MailSettingEntity>();



            using (var client = new SmtpClient())
            {
                MailAddress from = new MailAddress(mailSetting.Mail);
                MailMessage message = new MailMessage
                {
                    From = from
                };
                message.To.Add(mail);
                message.Subject = title;
                message.From = new MailAddress(mailSetting.Mail);
                message.Body = content;
                message.IsBodyHtml = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = mailSetting.Host;
                client.Port = mailSetting.Port;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential
                {
                    UserName = mailSetting.Mail,
                    Password = mailSetting.Password
                };
                client.Send(message);
            }



        }
    }
}
