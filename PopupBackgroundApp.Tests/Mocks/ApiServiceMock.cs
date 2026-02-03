using Moq;
using System.Collections.Generic;
using PopupBackgroundApp.Interfaces;
using PopupBackgroundApp.Models;

namespace PopupBackgroundApp.Tests.Mocks
{
    public static class ApiServiceMock
    {
        public static Mock<IApiService> CriarMockComSucesso()
        {
            var mock = new Mock<IApiService>();

            mock.Setup(api => api.BuscarCategoriasAsync())
                .ReturnsAsync(new List<string> { "dev", "money" });

            mock.Setup(api => api.BuscarPiadaPorCategoriaAsync(It.IsAny<string>()))
                .ReturnsAsync(new ChuckNorrisResponse
                {
                    Value = "Chuck Norris escreve código que não precisa de testes."
                });

            return mock;
        }

        public static Mock<IApiService> CriarMockComErro()
        {
            var mock = new Mock<IApiService>();

            mock.Setup(api => api.BuscarCategoriasAsync())
                .ThrowsAsync(new System.Exception("Erro ao buscar categorias"));

            return mock;
        }

        public static Mock<IApiService> CriarMockSemCategorias()
        {
            var mock = new Mock<IApiService>();

            mock.Setup(api => api.BuscarCategoriasAsync())
                .ReturnsAsync(new List<string>());

            return mock;
        }

        public static Mock<IApiService> CriarMockComPiadaInvalida()
        {
            var mock = new Mock<IApiService>();

            mock.Setup(api => api.BuscarCategoriasAsync())
                .ReturnsAsync(new List<string> { "dev" });

            mock.Setup(api => api.BuscarPiadaPorCategoriaAsync(It.IsAny<string>()))
                .ReturnsAsync(new ChuckNorrisResponse
                {
                    Value = ""
                });

            return mock;
        }

    }
}
