using Microsoft.Win32;
using System.Windows.Forms;

namespace PopupBackgroundApp.Utils
{
    public static class StartupManager
    {
        public static void Register()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

            rk.SetValue("PopupBackgroundApp", Application.ExecutablePath);
        }
    }
}
