using NUnit.Framework;
using PopupBackgroundApp.Core;
using PopupBackgroundApp.Tests.Mocks;
using System;
using System.Threading.Tasks;

namespace PopupBackgroundApp.Tests.Core
{
    [TestFixture]
    public class ApiServiceTests
    {
        private ApiService _service;

        [SetUp]
        public void Setup()
        {
            var mockApi = ApiServiceMock.CriarMockComSucesso();
            _service = new ApiService(mockApi.Object);
        }

        [Test]
        public async Task BuscarMensagemAsync_DeveRetornarMensagem_QuandoApiResponderCorretamente()
        {
            
            var resultado = await _service.BuscarMensagemAsync();

            
            Assert.That(resultado, Is.Not.Null);
            Assert.That(resultado, Is.Not.Empty);
            Assert.That(resultado, Does.Contain("Chuck Norris"));
        }

        [Test]
        public void BuscarMensagemAsync_DeveLancarExcecao_QuandoApiFalhar()
        {
           
            var mockApi = ApiServiceMock.CriarMockComErro();
            var serviceComErro = new ApiService(mockApi.Object);

            
            Assert.ThrowsAsync<System.Exception>(async () =>
            {
                await serviceComErro.BuscarMensagemAsync();
            });
        }

        [Test]
        public void BuscarMensagemAsync_QuandoApiNaoRetornaCategorias_DeveLancarExcecao()
        {
            // Arrange
            var mockApi = ApiServiceMock.CriarMockSemCategorias();
            var service = new ApiService(mockApi.Object);

            // Act + Assert
            Assert.ThrowsAsync<Exception>(async () =>
            {
                await service.BuscarMensagemAsync();
            });
        }

        [Test]
        public void BuscarMensagemAsync_QuandoApiRetornaPiadaInvalida_DeveLancarExcecao()
        {
            // Arrange
            var mockApi = ApiServiceMock.CriarMockComPiadaInvalida();
            var service = new ApiService(mockApi.Object);

            // Act + Assert
            Assert.ThrowsAsync<Exception>(async () =>
            {
                await service.BuscarMensagemAsync();
            });
        }

    }
}
