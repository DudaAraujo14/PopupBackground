using System;
using System.Threading;
using PopupBackgroundApp.Utils;

namespace PopupBackgroundApp.Core
{
    public static class TimerService
    {
        private static Timer _timer;

        public static void Start()
        {
            _timer = new Timer(
                Execute,
                null,
                TimeSpan.Zero,
                TimeSpan.FromMinutes(AppSettings.IntervaloMinutos)
            );
        }

        private static async void Execute(object state)
        {
            string mensagem = await ApiService.BuscarMensagem();
            NotificationService.Show(mensagem);
        }
    }
}
