using System.Windows.Forms;
using PopupBackgroundApp.Core;
using PopupBackgroundApp.Utils;

namespace PopupBackgroundApp
{
    static class Program
    {
        [System.STAThread]
        static void Main()
        {
            if (!SingleInstance.Start())
                return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            TimerService.Start();

            Application.Run();
        }
    }
}
