using System;
using System.Windows.Forms;
using PopupBackgroundApp.Core;
using PopupBackgroundApp.Utils;

namespace PopupBackgroundApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Garante apenas uma instância
            if (!SingleInstance.Start())
                return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicia o timer
            TimerService.Start();

            // Mantém rodando em background
            Application.Run();
        }
    }
}
