#if ANDROID
using Android.Text;
#endif
using Microsoft.Extensions.Logging;

namespace TestMauiControls;

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
        ConfigureCustomHandlers();

#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static void ConfigureCustomHandlers()
    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
        {
            if (view is not EntryRaw) return;
#if ANDROID
            if (!view.IsTextPredictionEnabled)
            {
                handler.PlatformView.InputType = InputTypes.ClassText | InputTypes.TextVariationVisiblePassword | InputTypes.TextFlagNoSuggestions;
            }
#elif WINDOWS
            handler.PlatformView.IsTextPredictionEnabled = false;
            handler.PlatformView.IsSpellCheckEnabled = false;
#endif
        });
    }
}
