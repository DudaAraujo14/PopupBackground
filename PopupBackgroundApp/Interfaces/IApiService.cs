using PopupBackgroundApp.Models;
using Refit;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace PopupBackgroundApp.Interfaces
{
    public interface IApiService
    {
        // 🔹 1) Endpoint de categorias
        [Get("/jokes/categories")]
        Task<List<string>> BuscarCategoriasAsync();

        // 🔹 2) Piada aleatória por categoria
        [Get("/jokes/random")]
        Task<ChuckNorrisResponse> BuscarPiadaPorCategoriaAsync(
            [AliasAs("category")] string category
        );

        // 🔹 3) Piada aleatória (sem categoria)
        [Get("/jokes/random")]
        Task<ChuckNorrisResponse> BuscarPiadaAsync();
    }
}
