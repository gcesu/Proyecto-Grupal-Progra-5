using Farmacia.BLL.Interface;
using Farmacia.BLL.Service;
using Microsoft.Extensions.Logging;
using Radzen;

namespace Farmacia
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
                });

            builder.Services.AddMauiBlazorWebView();


            builder.Services.AddSingleton<ICliente, sCliente>(); // Inyeccion de dependencia de la interfaz ICliente
            builder.Services.AddSingleton<IMedicamento, sMedicamento>(); // Inyeccion de dependencia de la interfaz IProducto
            builder.Services.AddSingleton<IClienteMedicamento, sClienteMedicamento>(); // Inyeccion de dependencia de la interfaz IVenta

            builder.Services.AddRadzenComponents();
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<TooltipService>();
            builder.Services.AddScoped<ContextMenuService>();
            builder.Services.AddScoped<ThemeService>(); // Servicio de temas

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
