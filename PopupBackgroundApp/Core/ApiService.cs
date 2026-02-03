using System;
using System.Threading.Tasks;
using PopupBackgroundApp.Interfaces;
using PopupBackgroundApp.Utils;
using Refit;

namespace PopupBackgroundApp.Core
{
    public class ApiService
    {
        private readonly IApiService _api;
        private readonly Random _random;

        public ApiService()
        {
            _api = RestService.For<IApiService>(AppSettings.ApiUrl);
            _random = new Random();
        }

        public ApiService(IApiService api)
        {
            _api = api;
            _random = new Random();
        }

        public async Task<string> BuscarMensagemAsync()
        {
            var categorias = await _api.BuscarCategoriasAsync();

            if (categorias == null || categorias.Count == 0)
                throw new Exception("Nenhuma categoria encontrada");

            var categoria = categorias[_random.Next(categorias.Count)];

            var piada = await _api.BuscarPiadaPorCategoriaAsync(categoria);

            if (piada == null || string.IsNullOrWhiteSpace(piada.Value))
                throw new Exception("Piada inválida");

            return piada.Value;
        }
    }
}
