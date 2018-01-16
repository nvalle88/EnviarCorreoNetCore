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

        public async Task<bool> Enviar(int tipo, string cuerpo)
        {
      
            var Adscmailconf = new Adscmailconf
            {
                AdcfTipo = tipo
            };

            var respuesta = await Servicio.ObtenerElementoAsync1<ResponseCorreo>(Adscmailconf, new Uri(ConfiguracionCorreo.servicioSeguridad),
                                                               "/api/Adscmailconfs/ObtenerCorreoSegunTipo");
            if (!respuesta.IsSuccess)
            {
                return false;
            }
            var sdscmailconf = JsonConvert.DeserializeObject<Adscmailconf>(respuesta.Resultado.ToString());
            return await SendEmailAsync(sdscmailconf.AdcfCorreo, sdscmailconf.AdcfAsunto, cuerpo);
           
        }

        public async Task<bool> SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress(ConfiguracionCorreo.NombreEmisor, ConfiguracionCorreo.DeEmail));
                emailMessage.To.Add(new MailboxAddress(ConfiguracionCorreo.NombreReceptor, email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart("plain") { Text = message };

                using (var client = new SmtpClient())
                {
                    client.LocalDomain = ConfiguracionCorreo.DominioPrimario;
                    await client.ConnectAsync(ConfiguracionCorreo.HostUri, ConfiguracionCorreo.PuertoPrimario, SecureSocketOptions.None).ConfigureAwait(false);
                    await client.SendAsync(emailMessage).ConfigureAwait(false);
                    await client.DisconnectAsync(true).ConfigureAwait(false);
                }
                return true;
            }
            catch (Exception )
            {

                return false;
            }
        }
    }
}  
 

