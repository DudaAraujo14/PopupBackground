using System;
using System.Threading;
using PopupBackgroundApp.Utils;

namespace PopupBackgroundApp.Core
{
    public static class TimerService
    {
        private static Timer _timer;
        private static ApiService _apiService;

        public static void Start()
        {
            _apiService = new ApiService();

            _timer = new Timer(      
                Execute,
                null,
                TimeSpan.Zero,
                TimeSpan.FromMinutes(AppSettings.IntervaloMinutos)
            );
        }

        private static async void Execute(object state)
        {
            string mensagem = await _apiService.BuscarMensagemAsync();
            RegistroService.Show(mensagem);
        }
    }
}
