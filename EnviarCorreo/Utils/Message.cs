using MimeKit;
using SendMails.methods;

namespace SendMails.Utils
{
    public static class Message
    {
        public static MailBox InicializeMessage(Mail mail)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(mail.NameFrom, mail.EmailFrom));
            emailMessage.To.Add(new MailboxAddress(mail.NameTo, mail.EmailTo));
            emailMessage.Subject = mail.Subject;
            emailMessage.Body = new TextPart("plain") { Text = mail.Body };
            return new MailBox { Mail=mail,MimeMessage=emailMessage};
        }

    }
}
