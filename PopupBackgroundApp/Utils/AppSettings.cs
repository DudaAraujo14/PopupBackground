using System.Configuration;

namespace PopupBackgroundApp.Utils
{
    public static class AppSettings
    {
        public static bool Ativo =>
            bool.Parse(ConfigurationManager.AppSettings["Ativo"]);

        public static int IntervaloMinutos =>
            int.Parse(ConfigurationManager.AppSettings["IntervaloMinutos"]);

        public static string ApiUrl =>
            ConfigurationManager.AppSettings["ApiUrl"];

        public static string CaminhoArquivo =>
            ConfigurationManager.AppSettings["CaminhoArquivo"];

        public static string NomeArquivo =>
            ConfigurationManager.AppSettings["NomeArquivo"];
    }
}
