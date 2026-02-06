using Refit;
using System.Threading.Tasks;

namespace PopupBackgroundApp.Interfaces
{
    public interface IApiService
    {
        [Post("/client/v1/process/{processId}")]
        Task<string> ConsultarStatusFormalizacaoAsync(string processId);
    }
}
