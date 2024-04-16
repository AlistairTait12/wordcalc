using WordCalc.Presentation.ViewModel;

namespace WordCalc.Presentation.View;

public partial class TurnPage : ContentPage
{
    public TurnPage(TurnViewModel testViewModel)
    {
        InitializeComponent();
        BindingContext = testViewModel;
    }
}