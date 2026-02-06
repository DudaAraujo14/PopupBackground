using Refit;
using System.Threading.Tasks;

namespace PopupBackgroundApp.Interfaces
{
    /// <summary>
    /// Interface da Api da Unico para consulta de status de formalização
    /// </summary>
    public interface IApiUnicoService
    {
        [Post("/client/v1/process/{processId}")]
        Task<string> ConsultarStatusFormalizacaoAsync(string processId);
    }
}
