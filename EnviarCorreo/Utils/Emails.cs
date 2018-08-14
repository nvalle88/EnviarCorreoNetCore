using MailKit.Net.Smtp;
using MimeKit;
using SendMail.Utils;
using SendMails.Constant;
using SendMails.methods;
using SendMails.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnviarCorreo
{
    public static class Emails
    {

        private static string SendingEmail(MailBox mailBox)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    client.Connect(MailConfig.HostUri, MailConfig.PrimaryPort, SecureSocketOption.GetSecureSocketOptions());
                    if (MailConfig.RequireAuthentication)
                    {
                        client.Authenticate(MailConfig.UserName, MailConfig.Password);
                    };
                    client.Send(mailBox.MimeMessage);
                    client.Disconnect(true);
                }
                return Constant.True;
            }
            catch (Exception ex)
            {
                return ex.InnerException.ToString();
            }
        }


        private  static async Task<string> SendingEmailAsync(MailBox mailBox )
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    client.Connect(MailConfig.HostUri, MailConfig.PrimaryPort, SecureSocketOption.GetSecureSocketOptions());
                    if (MailConfig.RequireAuthentication)
                    {
                        client.Authenticate(MailConfig.UserName, MailConfig.Password);
                    }
                    await client.SendAsync(mailBox.MimeMessage);
                    client.Disconnect(true);
                }
                return Constant.True;
            }
            catch (Exception ex)
            {
                return ex.InnerException.ToString();
            }
        }



        #region synchronous

        /// <summary>
        /// Send a simple email synchronous
        /// </summary>
        /// <param name="mail"></param>
        /// <returns>Is Success return true else return the exception</returns>
        public static string SendEmail(Mail mail )
        {
            try
            {
                return SendingEmail(Message.InicializeMessage(mail));
            }
            catch (Exception ex)
            {
                return ex.InnerException.Message;
                throw;
            }
        }

        /// <summary>
        /// Send a list the emails synchronous
        /// </summary>
        /// <param name="list"></param>
        /// <returns>If is Success return true else return the exception</returns>
        public static string SendEmail(List<Mail> list)
        {
            try
            {
                foreach (var item in list)
                {
                    SendingEmail(Message.InicializeMessage(item));
                }

                return Constant.True;
            }
            catch (Exception ex)
            {
                return ex.InnerException.Message;
            }

        }

        #endregion


        #region Async
        /// <summary>
        /// Send a simple email Async
        /// </summary>
        /// <param name="mail"></param>
        /// <returns>If is Success return true else return the exception</returns>
        public static async  Task<string> SendEmailAsync(Mail mail )
        {
            try
            {
                return await SendingEmailAsync(Message.InicializeMessage(mail));
            }
            catch (Exception ex)
            {
                return ex.InnerException.Message;
                throw;
            }
        }

        /// <summary>
        /// Send a list the emails Async
        /// </summary>
        /// <param name="list"></param>
        /// <returns>If is Success return true else return the exception</returns>
        public static async Task<string> SendEmailAsync(List<Mail> list )
        {
            try
            {
                foreach (var item in list)
                {
                   await SendingEmailAsync(Message.InicializeMessage(item));
                }

                return Constant.True;
            }
            catch (Exception ex)
            {
                return ex.InnerException.Message;
            }
        } 
        #endregion


    }
}

