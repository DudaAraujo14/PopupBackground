using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PopupBackgroundApp.Interfaces;
using PopupBackgroundApp.Models;
using PopupBackgroundApp.Utils;
using Refit;

namespace PopupBackgroundApp.Core
{
    public static class ApiService
    {
        // Reusar HttpClient é uma boa prática (evita ficar criando/descartando toda hora)
        private static readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri(AppSettings.ApiUrl)
        };

        private static readonly IApiService _api =
            RestService.For<IApiService>(
                _httpClient,
                new RefitSettings
                {
                    ContentSerializer = new NewtonsoftJsonContentSerializer()
                });

        public static async Task<string> BuscarMensagem()
        {
            var response = await _api.BuscaPiada();
            return response?.value ?? "Mensagem indisponível";
        }
    }
}
