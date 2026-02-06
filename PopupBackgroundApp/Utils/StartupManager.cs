using Microsoft.Win32;
using System.Windows.Forms;

namespace PopupBackgroundApp.Utils
{
    public static class StartupManager
    {
        public static void Register()
        {
            var key = Registry.CurrentUser.OpenSubKey(
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

            key.SetValue("PopupBackgroundApp", Application.ExecutablePath);
        }
    }
}
