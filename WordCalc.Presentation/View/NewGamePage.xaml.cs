using WordCalc.Presentation.ViewModel;

namespace WordCalc.Presentation.View;


public partial class NewGamePage : ContentPage
{
    public NewGamePage(NewGameViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}