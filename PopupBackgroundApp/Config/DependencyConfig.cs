using Microsoft.Extensions.DependencyInjection;
using PopupBackgroundApp.Interfaces;
using PopupBackgroundApp.Core;
using System.Windows.Forms;
using PopupBackgroundApp.Utils;
using Refit;
using System;

namespace PopupBackgroundApp.Config
{
    public static class DependencyConfig
    {
        public static ServiceProvider Configure()
        {
            var services = new ServiceCollection();

            services.AddSingleton<ApplicationContext>();

            services.AddSingleton<ITimerService, TimerService>();

            //ADICIONANDO APIS EXTERNAS
            services.AddRefitClient<IapiUnicoAuthService>()
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(AppSettings.AuthBaseUrl); // ex: "https://api.unico.io"
            });
            services.AddRefitClient<IApiUnicoService>()
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(AppSettings.ApiBaseUrl);
            });
            
            //REGISTRANDO SERVIÇOS INTERNOS
            services.AddTransient<IApiUnico, ApiUnico>();
            services.AddTransient<IAuthUnico, AuthUnico>();

            return services.BuildServiceProvider();
        }
    }
}
