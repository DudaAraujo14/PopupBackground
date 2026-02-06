using System;
using System.Threading;
using PopupBackgroundApp.Utils;
using PopupBackgroundApp.Interfaces;
using System;
using System.CodeDom.Compiler;
using System.Threading.Tasks;
using Windows.Services.Maps;

namespace PopupBackgroundApp.Core
{
    public interface ITimerService
    {
        void Start();
    }

    public class TimerService : ITimerService
    {
        private readonly IApiUnico _apiService;

        private  Timer _timer;

        public TimerService()
        { 
            
        }

        public void Start()
        {
            if (!AppSettings.Ativo)
                return;

            _timer = new Timer(
                async _ => await ExecuteAsync(),
                null,
                TimeSpan.Zero,
                TimeSpan.FromMinutes(AppSettings.IntervaloMinutos)
            );
        }

        private async Task ExecuteAsync()
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
