using System;
using System.IO;

namespace PopupBackgroundApp.Utils
{
    public static class ErrorLogService
    {
        private static readonly string caminhoErro =
            $"{AppSettings.CaminhoArquivo}/error.log";

        public static void Registrar(Exception excecao)
        {
            try
            {
                string mensagem =
                    $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | ERRO{Environment.NewLine}" +
                    $"{excecao.Message}{Environment.NewLine}" +
                    $"{excecao.StackTrace}{Environment.NewLine}" +
                    $"--------------------------------------{Environment.NewLine}";

                File.AppendAllText(caminhoErro, mensagem);
            }
            catch
            {
                // erro nunca pode derrubar o sistema
            }
        }
    }
}
