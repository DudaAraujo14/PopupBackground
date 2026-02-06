using System;
using System.IO;

namespace PopupBackgroundApp.Utils
{
    public static class LogService
    {
        private static readonly string CaminhoCompleto =
            $"{AppSettings.CaminhoArquivo}/{AppSettings.NomeArquivo}";

        public static void Registrar(string mensagem)
        {
            try
            {
                Directory.CreateDirectory(
                    Path.GetDirectoryName(CaminhoCompleto)
                );

                var linha =
                    $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {mensagem}{Environment.NewLine}";

                File.AppendAllText(CaminhoCompleto, linha);
            }
            catch
            {
                // log nunca pode derrubar o sistema
            }
        }
    }
}
