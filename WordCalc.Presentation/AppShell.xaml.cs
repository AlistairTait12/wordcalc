using WordCalc.Presentation.View;

namespace WordCalc.Presentation;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(NewGamePage), typeof(NewGamePage));
        Routing.RegisterRoute(nameof(TurnPage), typeof(TurnPage));
    }
}
