
using EnviarCorreo;
using SendMails.methods;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
   public class Program
    {
      public  static void Main(string[] args)
        {
            MailConfig.HostUri = "smtp.gmail.com";
            MailConfig.PrimaryPort = 465;
            MailConfig.SecureSocketOptions = 2;
            MailConfig.RequireAuthentication = true;
            MailConfig.UserName = "nestorvalle880416@gmail.com";
            MailConfig.Password = "Nvr1604**@NVR";

            MailConfig.EmailFrom = "PEPITO";
            MailConfig.NameFrom = "PEPE";


            var listaCorreo = new List<Mail>();
            
                var mail = new Mail
                {
                    Body = "Prueba Correos"
                               ,
                    EmailTo = "nestorvalle880416@gmail.com"
                               ,
                    NameTo = "Usuario"
                               ,
                    Subject = "Prueba Correos para datos",
                };


            var mail1 = new Mail
            {
                Body = "Prueba Correos"
                             ,
                EmailTo = "rodolfo.escobar@bde.fin.ec"
                             ,
                NameTo = "Usuario"
                             ,
                Subject = "Prueba Correos",
            };

            var mail2 = new Mail
            {
                Body = "Prueba Correos"
                            ,
                EmailTo = "mirna.fernandez@bde.fin.ec"
                            ,
                NameTo = "Usuario"
                            ,
                Subject = "Prueba Correos",
            };

            var mail3 = new Mail
            {
                Body = "Prueba Correos"
                           ,
                EmailTo = "lorena.arroyo@bde.fin.ec"
                           ,
                NameTo = "Usuario"
                           ,
                Subject = "Prueba Correos",
            };


            listaCorreo.Add(mail);
            listaCorreo.Add(mail1);
            listaCorreo.Add(mail2);
            listaCorreo.Add(mail3);

            //execute the method Send Mail or SendMailAsync
            var a = Emails.SendEmailAsync(mail);
            Console.WriteLine(a);
            Console.ReadLine();

        }
    }
}
