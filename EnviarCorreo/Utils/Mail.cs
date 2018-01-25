using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;

namespace EnviarCorreo
{
    public static class Mail
    {

        public static string SendEmail()
        {
            var secureSocketOptions = SecureSocketOptions.None;
            try
            {
                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress(MailConfig.NameFrom, MailConfig.EmailFrom));
                emailMessage.To.Add(new MailboxAddress(MailConfig.NameTo,MailConfig.EmailTo));
                emailMessage.Subject = MailConfig.Subject;
                emailMessage.Body = new TextPart("plain") { Text = MailConfig.Body};

               
                switch (MailConfig.SecureSocketOptions)
                {
                    case 1:
                        secureSocketOptions = SecureSocketOptions.Auto;
                        break;
                    case 2:
                        secureSocketOptions = SecureSocketOptions.SslOnConnect;
                        break;
                    case 3:
                        secureSocketOptions = SecureSocketOptions.StartTls;
                        break;
                    case 4:
                        secureSocketOptions = SecureSocketOptions.StartTlsWhenAvailable;
                        break;
                }

                using (var client = new SmtpClient())
                {
                    client.Connect(MailConfig.HostUri, MailConfig.PrimaryPort, secureSocketOptions);
                    client.Authenticate(MailConfig.EmailFrom, MailConfig.Password);
                     client.Send(emailMessage);
                     client.Disconnect(true);
                }
                return "true";
            }
            catch (Exception ex)
            {

                return ex.InnerException.ToString();
            }
        }
    }
}

