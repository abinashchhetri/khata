
using finalKhata.Configs;
using Microsoft.Extensions.Logging;

namespace finalKhata
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            FolderAndFiles.CreateFolder();
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("PublicSans-VariableFont_wght.ttf", "OpenSansRegular");
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
