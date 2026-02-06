using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopupBackgroundApp.Interfaces
{
    /// <summary>
    /// interface do serviço de obtenção de token da Unico "Interno Catarse"
    /// </summary>
    public interface IAuthUnico
    {
        Task<string> ObterBearerTokenAsync();
    }
}
