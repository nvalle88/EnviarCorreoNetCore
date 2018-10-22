
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
            MailConfig.UserName = "";
            MailConfig.Password = "";

            MailConfig.EmailFrom = "PEPITO";
            MailConfig.NameFrom = "PEPE";


            var listaCorreo = new List<Mail>();
            
                var mail = new Mail
                {
                    Body = "<b>Prueba Correos</b>"
                               ,
                    EmailTo = ""
                               ,
                    NameTo = "Usuario"
                               ,
                    Subject = "Prueba Correos para datos",
                };



            listaCorreo.Add(mail);
           

            //execute the method Send Mail or SendMailAsync
            var a = Emails.SendEmailAsync(listaCorreo);
            Console.WriteLine(a);
            Console.ReadLine();

        }
    }
}
