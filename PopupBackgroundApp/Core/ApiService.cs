using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PopupBackgroundApp.Models;
using PopupBackgroundApp.Utils;

namespace PopupBackgroundApp.Core
{
    public static class ApiService
    {
        public static async Task<string> BuscarMensagem()
        {
            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(AppSettings.ApiUrl);

                ChuckNorrisResponse response =
                    JsonConvert.DeserializeObject<ChuckNorrisResponse>(json);

                return response?.value ?? "Mensagem indisponível";
            }
        }
    }
}
