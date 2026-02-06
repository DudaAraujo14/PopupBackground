using System;
using System.Threading.Tasks;
using PopupBackgroundApp.Interfaces;
using PopupBackgroundApp.Utils;

namespace PopupBackgroundApp.Core
{
    public class TimerExecutor
    {
        private readonly IApiUnico _apiService;

        public TimerExecutor(
            IApiUnico apiUnico
        )
        {
            _apiService = apiUnico;
        }

        public async Task ExecuteAsync()
        {
            try
            {
                var resultado = await _apiService.ConsultarStatusFormalizacao("GUID-EXEMPLO");
                LogService.Registrar(resultado);
            }
            catch (Exception ex)
            {
                LogService.Registrar($"ERRO: {ex.Message}");
            }
        }
    }
}
