using WordCalc.Presentation.View;

namespace WordCalc.Presentation;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void NewGameButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NewGamePage));
    }
}

