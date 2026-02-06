using PopupBackgroundApp.Models;
using Refit;
using System.Threading.Tasks;

namespace PopupBackgroundApp.Interfaces
{
    public interface IAuthApi
    {
        [Post("/oauth2/token")]
        Task<TokenResponse> GerarTokenAsync([Body] OAuthRequest request);
    }
}
