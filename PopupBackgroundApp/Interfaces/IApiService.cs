using PopupBackgroundApp.Models;
using Refit;
using System.Threading.Tasks;

namespace PopupBackgroundApp.Interfaces
{
    interface IApiService
    {
        [Get("/jokes/random")]
        Task<ChuckNorrisResponse> BuscaPiadaPorCategoria([Query] string category);

        [Get("/jokes/random")]
        Task<ChuckNorrisResponse> BuscaPiada();
    }
}
