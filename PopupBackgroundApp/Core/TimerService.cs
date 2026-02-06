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
            if (!AppSettings.Ativo)
                return;

            var executor = new TimerExecutor();

            _timer = new Timer(
                async _ => await executor.ExecuteAsync(),
                null,
                TimeSpan.Zero,
                TimeSpan.FromMinutes(AppSettings.IntervaloMinutos)
            );
        }
    }
}
