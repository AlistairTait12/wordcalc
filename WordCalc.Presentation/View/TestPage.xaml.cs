using WordCalc.Presentation.ViewModel;

namespace WordCalc.Presentation.View;

public partial class TestPage : ContentPage
{
    public TestPage(TestViewModel testViewModel)
    {
        InitializeComponent();
        BindingContext = testViewModel;
    }
}