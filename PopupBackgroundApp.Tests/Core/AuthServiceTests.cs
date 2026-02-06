using NUnit.Framework;
using Moq;
using PopupBackgroundApp.Core;
using PopupBackgroundApp.Interfaces;
using PopupBackgroundApp.Models;
using System;
using System.Threading.Tasks;

namespace PopupBackgroundApp.Tests.Core
{
    [TestFixture]
    public class AuthServiceTests
    {
        [Test]
        public async Task ObterBearerTokenAsync_DeveRetornarToken_QuandoApiResponderComSucesso()
        {
            var authApiMock = new Mock<IAuthApi>();

            authApiMock
                .Setup(api => api.GerarTokenAsync(It.IsAny<OAuthRequest>()))
                .ReturnsAsync(new TokenResponse
                {
                    AccessToken = "TOKEN_FAKE",
                    ExpiresIn = 300
                });

            var service = new AuthService(authApiMock.Object);

            var token = await service.ObterBearerTokenAsync();

            Assert.That(token, Is.EqualTo("TOKEN_FAKE"));
        }

        [Test]
        public void ObterBearerTokenAsync_DeveLancarExcecao_QuandoTokenForVazio()
        {
            var authApiMock = new Mock<IAuthApi>();

            authApiMock
                .Setup(api => api.GerarTokenAsync(It.IsAny<OAuthRequest>()))
                .ReturnsAsync(new TokenResponse
                {
                    AccessToken = string.Empty,
                    ExpiresIn = 0
                });

            var service = new AuthService(authApiMock.Object);

            Assert.ThrowsAsync<Exception>(async () =>
            {
                await service.ObterBearerTokenAsync();
            });
        }

        [Test]
        public void ObterBearerTokenAsync_DeveLancarExcecao_QuandoApiRetornarErro()
        {
            var authApiMock = new Mock<IAuthApi>();
            
            authApiMock
                .Setup(api => api.GerarTokenAsync(It.IsAny<OAuthRequest>()))
                .ThrowsAsync(new Exception("401 Unauthorized"));

            var service = new AuthService(authApiMock.Object);

            Assert.ThrowsAsync<Exception>(async () =>
            {
                await service.ObterBearerTokenAsync();
            });
        }
    }
}
