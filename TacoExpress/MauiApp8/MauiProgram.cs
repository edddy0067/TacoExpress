using Microsoft.Extensions.Logging;
using MauiApp8.Services;
using MauiApp8.ViewModels;
using MauiApp8.Views;

namespace MauiApp8
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            //Registro Services
            builder.Services.AddSingleton<ApiClient>();
            builder.Services.AddSingleton<AuthService>();
            builder.Services.AddSingleton<PedidoService>();
            builder.Services.AddSingleton<WeatherService>();

            //Registro ViewModels
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<MenuViewModel>();
            builder.Services.AddTransient<CarritoViewModel>();
            builder.Services.AddTransient<PedidoViewModel>();

            //Registro Views
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<MenuPage>();
            builder.Services.AddTransient<CarritoPage>();
            builder.Services.AddTransient<PedidoPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
