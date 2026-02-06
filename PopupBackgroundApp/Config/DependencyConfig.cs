using Microsoft.Extensions.DependencyInjection;
using PopupBackgroundApp.Interfaces;
using PopupBackgroundApp.Core;

namespace PopupBackgroundApp.Config
{
    public static class DependencyConfig
    {
        public static ServiceProvider Configure()
        {
            var services = new ServiceCollection();

            services.AddSingleton<ITimerService, TimerService>();

            // Registrando serviços
            services.AddTransient<IApiUnico, ApiUnico>();
            services.AddTransient<IAuthUnico, AuthUnico>();

            return services.BuildServiceProvider();
        }
    }
}
