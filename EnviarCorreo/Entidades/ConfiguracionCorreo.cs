using System;

namespace EnviarCorreo
{
    public static class ConfiguracionCorreo
    {

        public static string NombreEmisor { get; set; } //Nombre de Funcionario que envía el correo

        public static string NombreReceptor { get; set; } //Nombre de Funcionario que recibe el correo

        public static string HostUri { get; set; } //SMTP Server (Host) por ejemplo smtp.gmail.com para gmail

        public static int PuertoPrimario { get; set; } //Puerto que usa Server SMTP por ejemplo 587 para gmail

        public static int PuertoSecundario { get; set; } // En caso de que se utilice otro puerto

        public static string NombreUsuario { get; set; } // Nombre de usuario del correo que envía

        public static string Contrasenia { get; set; } // Contrasenia del correo que envía

        public static string DeEmail { get; set; } //Correo de funcionario que envía 

        public static string ParaEmail { get; set; } //Correo de funcionario que recibe

        public static string servicioSeguridad { get; set; } //Variable parametrizable para acceder al Servicio de Seguridad

        public static int SecureSocketOptions { get; set; } // Variable parametrizable de opción de socket seguro

    }
}
