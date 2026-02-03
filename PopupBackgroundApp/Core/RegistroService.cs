using PopupBackgroundApp.Utils;

namespace PopupBackgroundApp.Core
{
    public static class RegistroService
    {
        public static void Show(string mensagem)
        {
            LogService.Registrar(mensagem);
        }
    }
}
