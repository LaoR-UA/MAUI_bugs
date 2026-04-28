using Microsoft.Extensions.Logging;

using TestMauiControls.ViewModels;

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

        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<SecondPageViewModel>();
        builder.Services.AddTransient<ThirdPageViewModel>();

        Routing.RegisterRoute(StaticDataContainer.SecondPageRoute, typeof(SecondPage));
        Routing.RegisterRoute(StaticDataContainer.ThirdPageRoute, typeof(ThirdPage));

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
