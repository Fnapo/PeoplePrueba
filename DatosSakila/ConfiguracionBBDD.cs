using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace DatosSakila
{
    // All the code in this file is included in all platforms.
    public static class ConfiguracionBBDD
    {
        private static IConfiguration? _configuracion = null;

        public static string? ObtenerCadenaConexion()
        {
            string? salida;

            if (_configuracion == null)
            {
                var a = Assembly.GetExecutingAssembly();

                using Stream? stream = a.GetManifestResourceStream("DatosSakila.Configuracion.json");
                {
                    if (stream == null) return "";

                    _configuracion = new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();
                }
            }
            salida = _configuracion["CadenaMySql"];
#if WINDOWS || NETCOREAPP
			salida += ";SslMode=Required;";
#else
            salida += ";SslMode=none;AllowPublicKeyRetrieval=True;";
#endif

            return salida;
        }
    }
}
