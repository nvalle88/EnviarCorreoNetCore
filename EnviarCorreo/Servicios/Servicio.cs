using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace bd.webappth.servicios.Servicios
{

    public static class Servicio
    {
        public static async Task<T> ObtenerElementoAsync1<T>(object model, Uri baseAddress, string url) where T : class
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var request = JsonConvert.SerializeObject(model);
                    var content = new StringContent(request, Encoding.UTF8, "application/json");

                    var uri = string.Format("{0}{1}", baseAddress, url);

                    var response = await client.PostAsync(new Uri(uri), content);

                    var resultado = await response.Content.ReadAsStringAsync();
                    var respuesta = JsonConvert.DeserializeObject<T>(resultado);
                    return respuesta;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}