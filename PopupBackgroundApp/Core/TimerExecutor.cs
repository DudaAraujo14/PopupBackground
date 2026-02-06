using System;
using System.Threading.Tasks;
using PopupBackgroundApp.Utils;

namespace PopupBackgroundApp.Core
{
    public class TimerExecutor
    {
        private readonly ApiService _apiService;

        public TimerExecutor()
        {
            _apiService = new ApiService();
        }

        public async Task ExecuteAsync()
        {
            try
            {
                var resultado = await _apiService.ConsultarStatusAsync("GUID-EXEMPLO");
                LogService.Registrar(resultado);
            }
            catch (Exception ex)
            {
                LogService.Registrar($"ERRO: {ex.Message}");
            }
        }
    }
}
