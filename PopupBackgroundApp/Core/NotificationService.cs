using System.Windows.Forms;

namespace PopupBackgroundApp.Core
{
    public static class NotificationService
    {
        public static void Show(string message)
        {
            MessageBox.Show(
                message,
                "Chuck Norris Diz:",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
