using System.Configuration;

namespace PopupBackgroundApp.Utils
{
    public static class AppSettings
    {
        // ===== CONTROLE DO TIMER =====
        public static bool Ativo =>
            bool.Parse(ConfigurationManager.AppSettings["Ativo"]);

        public static int IntervaloMinutos =>
            int.Parse(ConfigurationManager.AppSettings["IntervaloMinutos"]);

        // ===== API CHUCK / GERAL =====
        public static string ApiBaseUrl =>
            ConfigurationManager.AppSettings["ApiBaseUrl"];

        // ===== AUTH ÚNICO =====
        public static string AuthBaseUrl =>
            ConfigurationManager.AppSettings["AuthBaseUrl"];

        public static string UsuarioUnico =>
            ConfigurationManager.AppSettings["UsuarioUnico"];

        public static string SenhaUnico =>
            ConfigurationManager.AppSettings["SenhaUnico"];

        // ===== LOG =====
        public static string CaminhoArquivo =>
            ConfigurationManager.AppSettings["CaminhoArquivo"];

        public static string NomeArquivo =>
            ConfigurationManager.AppSettings["NomeArquivo"];
    }
}
