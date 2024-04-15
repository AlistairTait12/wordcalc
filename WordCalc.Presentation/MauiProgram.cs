using Microsoft.Extensions.Logging;
using WordCalc.Logic;
using WordCalc.Presentation.Components;
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
        builder.Services.AddTransient<NewGamePage>();
        builder.Services.AddTransient<TestPage>();
        builder.Services.AddTransient<TestViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
