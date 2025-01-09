using Microsoft.Extensions.Logging;
using Microsoft.Maui.Platform;
using Wordsmith.CustomControls;

#if ANDROID
using Wordsmith.Platforms.Android;
#endif

namespace Wordsmith
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
                })
                .ConfigureMauiHandlers(handlers =>
                {
#if ANDROID
                    handlers.AddHandler<CustomViewCell, CustomViewCellHandler>();
#endif
                });

#if DEBUG
                    builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}
