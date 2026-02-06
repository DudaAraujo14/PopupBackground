using NUnit.Framework;
using Newtonsoft.Json;
using PopupBackgroundApp.Models;

namespace PopupBackgroundApp.Tests.Models
{
    public class OAuthSerializationTests
    {
        [Test]
        public void OAuthRequest_DeveSerializarCorretamente()
        {
            var request = new OAuthRequest
            {
                GrantType = "password",
                Username = "usuario",
                Password = "senha"
            };

            var json = JsonConvert.SerializeObject(request);

            Assert.That(json, Does.Contain("grant_type"));
            Assert.That(json, Does.Contain("username"));
            Assert.That(json, Does.Contain("password"));
        }

        [Test]
        public void TokenResponse_DeveDesserializarCorretamente()
        {
            var json = @"{
                ""access_token"": ""TOKEN_TESTE"",
                ""expires_in"": 300
            }";

            var response = JsonConvert.DeserializeObject<TokenResponse>(json);

            Assert.That(response.AccessToken, Is.EqualTo("TOKEN_TESTE"));
            Assert.That(response.ExpiresIn, Is.EqualTo(300));
        }
    }
}
