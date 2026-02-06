

 using NUnit.Framework;
using Moq;
using PopupBackgroundApp.Core;
using PopupBackgroundApp.Interfaces;
using PopupBackgroundApp.Models;
using System.Threading.Tasks;

namespace PopupBackgroundApp.Tests.Core
{
    [TestFixture]
    public class AuthServiceTests
    {
        [Test]
        public async Task ObterBearerTokenAsync_DeveRetornarToken()
        {
            var authApiMock = new Mock<IAuthApi>();

            authApiMock
                .Setup(x => x.GerarTokenAsync(It.IsAny<OAuthRequest>()))
                .ReturnsAsync(new TokenResponse
                {
                    AccessToken = "TOKEN_FAKE",
                    ExpiresIn = 300
                });

            var service = new AuthService(authApiMock.Object);

            var token = await service.ObterBearerTokenAsync();

            Assert.That(token, Is.EqualTo("TOKEN_FAKE"));
        }
    }
}
