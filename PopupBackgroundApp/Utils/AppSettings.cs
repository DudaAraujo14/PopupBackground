using System.Configuration;

namespace PopupBackgroundApp.Utils
{
    public static class AppSettings
    {
        public static int IntervaloMinutos =>
            int.Parse(ConfigurationManager.AppSettings["IntervaloMinutos"]);

        public static string ApiUrl =>
            ConfigurationManager.AppSettings["ApiUrl"];


    }
}
