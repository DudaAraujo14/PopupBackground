using NUnit.Framework;
using PopupBackgroundApp.Core;
using System.Threading.Tasks;

namespace PopupBackgroundApp.Tests.Core
{
    [TestFixture]
    public class TimerExecutorTests
    {
        [Test]
        public void ExecuteAsync_NaoDeveLancarExcecao()
        {
            var executor = new TimerExecutor();

            Assert.DoesNotThrowAsync(async () =>
            {
                await executor.ExecuteAsync();
            });
        }
    }
}
