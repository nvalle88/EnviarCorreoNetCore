using System;

namespace EnviarCorreo
{
    public static class ConfiguracionCorreo
    {
        public static string DominioPrimario { get; set; }

        public static string NombreEmisor { get; set; }

        public static string NombreReceptor { get; set; }

        public static string HostUri { get; set; }

        public static int PuertoPrimario { get; set; }

        public static string DominioSecundario { get; set; }

        public static int PuertoSecundario { get; set; }

        public static string DeEmail { get; set; }

        public static string ParaEmail { get; set; }

        public static string servicioSeguridad { get; set; }



    }
}
