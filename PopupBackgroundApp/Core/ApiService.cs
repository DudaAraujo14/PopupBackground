using Refit;
using PopupBackgroundApp.Interfaces;
using PopupBackgroundApp.Utils;
using System.Threading.Tasks;

namespace PopupBackgroundApp.Core
{
    public class ApiService
    {
        private readonly AuthService _authService;

        public ApiService()
        {
            _authService = new AuthService();
        }

        public async Task<string> ConsultarStatusAsync(string processId)
        {
            var token = await _authService.ObterBearerTokenAsync();

            var api = RestService.For<IApiService>(
            AppSettings.ApiBaseUrl,
            new RefitSettings
        {
             AuthorizationHeaderValueGetter =
            (request, cancellationToken) =>
                Task.FromResult($"Bearer {token}")
    });


            var response = await api.ConsultarStatusFormalizacaoAsync(processId);

            if (string.IsNullOrWhiteSpace(response))
                throw new System.Exception("Resposta vazia da API da Único");

            return response;
        }
    }
}
