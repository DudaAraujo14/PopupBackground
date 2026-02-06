using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using PopupBackgroundApp.Config;
using PopupBackgroundApp.Core;
using PopupBackgroundApp.Utils;

namespace PopupBackgroundApp
{
    static class Program
    {

        private static ServiceProvider _provider;

        [System.STAThread]
        static void Main()
        {
            if (!SingleInstance.Start())
                return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _provider = DependencyConfig.Configure();

            var timer = _provider.GetRequiredService<ITimerService>();
            timer.Start();

            var ctx = _provider.GetRequiredService<ApplicationContext>();
            Application.Run(ctx);


        }
    }
}
