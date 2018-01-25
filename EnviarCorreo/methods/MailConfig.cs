using System;

namespace EnviarCorreo
{
    public static class MailConfig
    {

        public static string NameFrom { get; set; } 

        public static string NameTo { get; set; }

        public static string Subject { get; set; }

        public static string Body { get; set; }

        public static string HostUri { get; set; } 

        public static int PrimaryPort { get; set; }

        public static string Password { get; set; } 

        public static string EmailFrom { get; set; }

        public static string EmailTo { get; set; } 

        public static int SecureSocketOptions { get; set; }

    }
}
