using MimeKit;
using SendMails.methods;
using System;
using System.Collections.Generic;
using System.Text;

namespace SendMails.Utils
{
     public class MailBox
     {
        public MimeMessage MimeMessage { get; set; }
        public Mail Mail { get; set; }
    }
}
