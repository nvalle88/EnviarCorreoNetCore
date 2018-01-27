using EnviarCorreo;
using MailKit.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace SendMail.Utils
{
   public static class SecureSocketOption
    {
        public static SecureSocketOptions GetSecureSocketOptions()
        {
            var secureSocketOptions = SecureSocketOptions.None;

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
            return secureSocketOptions;
        }
    }
}
