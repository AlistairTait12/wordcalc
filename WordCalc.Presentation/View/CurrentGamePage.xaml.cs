using WordCalc.Presentation.ViewModel;

namespace WordCalc.Presentation.View;

public partial class CurrentGamePage : ContentPage
{
    public CurrentGamePage(CurrentGameViewModel currentGameViewModel)
    {
        InitializeComponent();
        BindingContext = currentGameViewModel;
    }
}
