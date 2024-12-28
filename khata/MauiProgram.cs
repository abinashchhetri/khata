using Microsoft.Extensions.Logging;

namespace khata
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
                    fonts.AddFont("OpenSans-Regular.ttf", "PublicSans");
                    fonts.AddFont("PublicSans-VariableFont_wght.ttf", "MainFont");
                    fonts.AddFont("EBGaramond-VariableFont_wght.ttf", "LogoFont");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
