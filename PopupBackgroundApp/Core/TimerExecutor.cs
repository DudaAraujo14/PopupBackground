using System;
using System.Threading.Tasks;
using PopupBackgroundApp.Utils;

namespace PopupBackgroundApp.Core
{
    public class TimerExecutor
    {
        private readonly ApiService _apiService;

        public TimerExecutor(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task ExecuteAsync()
        {
            try
            {
                var mensagem = await _apiService.BuscarMensagemAsync();
                RegistroService.Show(mensagem);
            }
            catch (Exception ex)
            {
                ErrorLogService.Registrar(ex);
            }
        }
    }
}
