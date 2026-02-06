using PopupBackgroundApp.Interfaces;
using PopupBackgroundApp.Models;
using PopupBackgroundApp.Utils;
using Refit;
using System.Threading.Tasks;

namespace PopupBackgroundApp.Core
{
    public class AuthUnico : IAuthUnico
    {
        private readonly IapiUnicoAuthService _authApi;

        
        public AuthUnico()
        {
            _authApi = RestService.For<IapiUnicoAuthService>(AppSettings.AuthBaseUrl);
        }

        // Teste (injeção)
        public AuthUnico(IapiUnicoAuthService authApi)
        {
            _authApi = authApi;
        }

        public async Task<string> ObterBearerTokenAsync()
        {
            var request = new OAuthRequest
            {
                GrantType = "password",
                Username = AppSettings.UsuarioUnico,
                Password = AppSettings.SenhaUnico
            };

            var response = await _authApi.GerarTokenAsync(request);

            if (response == null || string.IsNullOrWhiteSpace(response.AccessToken))
                throw new System.Exception("Falha ao obter token de autenticação");

            return response.AccessToken;
        }
    }
}
