using EnviarCorreo;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            MailConfig.HostUri = "smtp.gmail.com";
            MailConfig.PrimaryPort = 465;

            MailConfig.NameFrom = "Nestor";
            MailConfig.EmailFrom = "nestorvalle880416@gmail.com";
            MailConfig.Password = "nvr1604**";

            
            MailConfig.NameTo = "Valle";
            MailConfig.EmailTo = "nestorvalle880416@gmail.com";

            MailConfig.Subject = "Mensaje de prueba";
            MailConfig.Body = "Este es el nuguet";

            MailConfig.SecureSocketOptions = 2;

           var a= Mail.SendEmail();

            Console.WriteLine(a);
            Console.ReadLine();

        }
    }
}
