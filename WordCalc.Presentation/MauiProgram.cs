using Microsoft.Extensions.Logging;
using WordCalc.Logic;
using WordCalc.Presentation.View;
using WordCalc.Presentation.ViewModel;

namespace WordCalc.Presentation;
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

        builder.Services.AddSingleton<GameHandler>();

        builder.Services.AddTransient<NewGameViewModel>();
        builder.Services.AddTransient<CurrentGameViewModel>();
        builder.Services.AddTransient<TurnViewModel>();

        builder.Services.AddTransient<NewGamePage>();
        builder.Services.AddTransient<CurrentGamePage>();
        builder.Services.AddTransient<TurnPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
