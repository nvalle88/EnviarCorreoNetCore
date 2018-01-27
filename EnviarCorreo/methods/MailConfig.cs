namespace EnviarCorreo
{
    /// <summary>
    /// Configure the parameters generals.
    /// 
    /// </summary>
    public static class MailConfig
    {
        /// <summary>
        /// Host:example smtp.gmail.com
        /// </summary>
        public static string HostUri { get; set; } 

        /// <summary>
        /// Port the conecction:Example 465
        /// </summary>
        public static int PrimaryPort { get; set; }

        /// <summary>
        /// Sockets Options
        /// <para>SecureSocketOptions.None=0, No SSL or TLS encryption should be used.</para>
        /// <para>SecureSocketOptions.Auto=1, IMailService to decide which SSL or TLS options to use (default).</para>
        /// <para>SecureSocketOptions.SslOnConnect=2,The connection should use SSL or TLS encryption immediately.</para>
        /// <para>SecureSocketOptions.StartTls=3, Elevates the connection to use TLS encryption immediately after reading the greeting
        ///  and capabilities of the server. If the server does not support the STARTTLS extension,
        /// then the connection will fail and a System.</para>
        /// <para>SecureSocketOptions.StartTlsWhenAvailable=4, Elevates the connection to use TLS encryption immediately after reading the greeting
        /// and capabilities of the server, but only if the server supports the STARTTLS
        /// extension.  </para>
        /// </summary>
        public static int SecureSocketOptions { get; set; }

    }
}
