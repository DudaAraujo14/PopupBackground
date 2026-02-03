using NUnit.Framework;
using PopupBackgroundApp.Utils;
using System.IO;

namespace PopupBackgroundApp.Tests.Utils
{
    [TestFixture]
    public class LogServiceTests
    {
        private string _caminhoLog;

        [SetUp]
        public void Setup()
        {
            _caminhoLog =
                $"{AppSettings.CaminhoArquivo}/{AppSettings.NomeArquivo}";

            if (File.Exists(_caminhoLog))
                File.Delete(_caminhoLog);
        }

        [Test]
        public void Registrar_DeveCriarArquivoDeLog()
        {
            // Act
            LogService.Registrar("teste de log");

            // Assert
            Assert.That(File.Exists(_caminhoLog), Is.True);
        }

        [Test]
        public void Registrar_DeveGravarMensagemNoArquivo()
        {
            // Act
            LogService.Registrar("mensagem 1");
            LogService.Registrar("mensagem 2");

            // Assert
            var conteudo = File.ReadAllText(_caminhoLog);

            Assert.That(conteudo, Does.Contain("mensagem 1"));
            Assert.That(conteudo, Does.Contain("mensagem 2"));
        }
    }
}
