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

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<MenuPageViewModel>();
        builder.Services.AddTransient<SecondPageViewModel>();

        Routing.RegisterRoute("secondPage", typeof(SecondPage));

        return builder.Build();
    }
}
