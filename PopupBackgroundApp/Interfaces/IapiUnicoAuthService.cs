using PopupBackgroundApp.Models;
using Refit;
using System.Threading.Tasks;

namespace PopupBackgroundApp.Interfaces
{
    /// <summary>
    /// interface da unico para autorização
    /// </summary>
    public interface IapiUnicoAuthService
    {
        [Post("/oauth2/token")]
        Task<TokenResponse> GerarTokenAsync([Body] OAuthRequest request);
    }
}
