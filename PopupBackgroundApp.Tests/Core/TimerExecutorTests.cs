using Moq;
using NUnit.Framework;
using PopupBackgroundApp.Core;
using PopupBackgroundApp.Interfaces;
using PopupBackgroundApp.Models;
using System.Threading.Tasks;

namespace PopupBackgroundApp.Tests.Core
{
    [TestFixture]
    public class TimerExecutorTests
    {
        [Test]
        public void ExecuteAsync_NaoDeveLancarExcecao()
        {
            var authApiMock = new Mock<IApiUnico>();

            authApiMock
                .Setup(api => api.ConsultarStatusFormalizacao(It.IsAny<string>()))
                .ReturnsAsync(string.Empty);
            var executor = new TimerExecutor(authApiMock.Object);

            Assert.DoesNotThrowAsync(async () =>
            {
                await executor.ExecuteAsync();
            });
        }
    }
}
