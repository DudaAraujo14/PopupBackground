using Refit;
using PopupBackgroundApp.Interfaces;
using PopupBackgroundApp.Utils;
using System.Threading.Tasks;

namespace PopupBackgroundApp.Core
{
    public class ApiUnico : IApiUnico
    {
        private readonly IAuthUnico _authService;

        private readonly IApiUnicoService _apiService;
        public ApiUnico(
            IAuthUnico authUnico,
            IApiUnicoService apiUnicoService
        )
        {
            _authService = authUnico;
            _apiService = apiUnicoService;
        }

        public async Task<string> ConsultarStatusFormalizacao(string processId)
        {
            var token = await _authService.ObterBearerTokenAsync();

            var api = RestService.For<IApiUnicoService>(
            AppSettings.ApiBaseUrl,
            new RefitSettings
        {
             AuthorizationHeaderValueGetter =
            (request, cancellationToken) =>
                Task.FromResult($"Bearer {token}")
        });


            var response = await _apiService.ConsultarStatusFormalizacaoAsync(processId);

            if (string.IsNullOrWhiteSpace(response))
                throw new System.Exception("Resposta vazia da API da Único");

            return response;
        }
    }
}
