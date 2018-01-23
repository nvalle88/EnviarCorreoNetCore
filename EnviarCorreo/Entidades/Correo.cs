using bd.webappth.servicios.Servicios;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EnviarCorreo
{
    public class Correo
    {

        public  string Enviar(int tipo, string cuerpo)
        {

            var Adscmailconf = new Adscmailconf
            {
                AdcfTipo = tipo
            };

            var respuesta = Servicio.ObtenerElementoAsync1<ResponseCorreo>(Adscmailconf, new Uri(ConfiguracionCorreo.servicioSeguridad),
                                                               "api/Email/obtenerCorreo");
            if (!respuesta.Result.IsSuccess)
            {
                return "false";
            }
            var sdscmailconf = JsonConvert.DeserializeObject<Adscmailconf>(respuesta.Result.Resultado.ToString());
            return  SendEmailAsync(sdscmailconf.AdcfCorreo, sdscmailconf.AdcfAsunto, cuerpo);

        }

        public  string SendEmailAsync(string email, string subject, string message)
        {
            var opcionessocketseguro = SecureSocketOptions.None;
            try
            {
                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress(ConfiguracionCorreo.NombreEmisor, ConfiguracionCorreo.DeEmail));
                emailMessage.To.Add(new MailboxAddress(ConfiguracionCorreo.NombreReceptor, email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart("plain") { Text = message };

               
                switch (ConfiguracionCorreo.SecureSocketOptions)
                {
                    case 1:
                        opcionessocketseguro = SecureSocketOptions.Auto;
                        break;
                    case 2:
                        opcionessocketseguro = SecureSocketOptions.SslOnConnect;
                        break;
                    case 3:
                        opcionessocketseguro = SecureSocketOptions.StartTls;
                        break;
                    case 4:
                        opcionessocketseguro = SecureSocketOptions.StartTlsWhenAvailable;
                        break;
                }

                using (var client = new SmtpClient())
                {
                    client.Connect(ConfiguracionCorreo.HostUri, ConfiguracionCorreo.PuertoPrimario, opcionessocketseguro);
                    client.Authenticate(ConfiguracionCorreo.NombreUsuario, ConfiguracionCorreo.Contrasenia);
                     client.Send(emailMessage);
                     client.Disconnect(true);
                }
                return "true";
            }
            catch (Exception ex)
            {

                return ex.Message + "ConfiguracionCorreo.NombreEmisor= " + ConfiguracionCorreo.NombreEmisor+"\n"
                    + "ConfiguracionCorreo.DeEmail= " + ConfiguracionCorreo.DeEmail + "\n"
                    + "ConfiguracionCorreo.NombreReceptor= " + ConfiguracionCorreo.NombreReceptor + "\n"
                    + "email= " + email + "\n"
                    + "ConfiguracionCorreo.SecureSocketOptions" + ConfiguracionCorreo.SecureSocketOptions
                    + "ConfiguracionCorreo.HostUri" + ConfiguracionCorreo.HostUri
                    + "ConfiguracionCorreo.PuertoPrimario"+ ConfiguracionCorreo.PuertoPrimario
                    + "opcionessocketseguro" + opcionessocketseguro
                    + "ConfiguracionCorreo.NombreUsuario" + ConfiguracionCorreo.NombreUsuario
                    + "ConfiguracionCorreo.Contrasenia" + ConfiguracionCorreo.Contrasenia
                    ;
            }
        }
    }
}

