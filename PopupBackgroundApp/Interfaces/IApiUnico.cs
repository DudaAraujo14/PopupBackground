using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopupBackgroundApp.Interfaces
{
    /// <summary>
    /// interface do serviço da Unico "Interno Catarse"
    /// </summary>
    public interface IApiUnico
    {
        Task<string> ConsultarStatusFormalizacao(string processId);
    }
}
