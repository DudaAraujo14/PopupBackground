using Refit;
using System;
using System.Linq;
using System.Threading.Tasks;
using PopupBackgroundApp.Interfaces;

namespace PopupBackgroundApp.Core
{
    public class ApiService
    {
        private readonly IApiService _api;

        // 🔹 prefixo da URL configurado no construtor
        public ApiService()
        {
            _api = RestService.For<IApiService>(
                "https://api.chucknorris.io"
            );
        }

        public async Task<string> BuscarMensagemAsync()
        {
            // response → categorias
            var response = await _api.BuscarCategoriasAsync();

            if (response == null || response.Count == 0)
                return "Nenhuma categoria encontrada.";

            // escolhe uma categoria aleatória
            var categoria = response[new Random().Next(response.Count)];

            // response2 → piada da categoria
            var response2 = await _api.BuscarPiadaPorCategoriaAsync(categoria);

            return response2?.value ?? "Piada não encontrada.";
        }
    }
}
