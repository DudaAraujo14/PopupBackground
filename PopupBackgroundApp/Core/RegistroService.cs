using PopupBackgroundApp.Utils;

namespace PopupBackgroundApp.Core
{
    public static class RegistroService
    {
        public static void Show(string message)
        {
            //  grava no log (append)

            LogService.Registrar(message);
        }
    }
}
