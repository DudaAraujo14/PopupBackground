using System;
using System.IO;

namespace PopupBackgroundApp.Utils
{
    public static class LogService
    {
        private static readonly string caminhoCompletoDoLog =
            $"{AppSettings.CaminhoArquivo}/{AppSettings.NomeArquivo}";

        public static void Registrar(string mensagem)
        {
            try
            {
                Directory.CreateDirectory(
                    Path.GetDirectoryName(caminhoCompletoDoLog)
                );

                string linha =
                    $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {mensagem}{Environment.NewLine}";

                File.AppendAllText(caminhoCompletoDoLog, linha);
            }
            catch
            {
                // nunca quebrar a aplicação
            }
        }
    }
}
