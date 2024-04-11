using CommunityToolkit.Mvvm.ComponentModel;
using WordCalc.Logic.Models;

namespace WordCalc.Presentation.ViewModel;

public partial class TestViewModel : ObservableObject
{
    [ObservableProperty]
    WordComponentModel wordComponentModel;

    public TestViewModel()
    {
        WordComponentModel = new WordComponentModel();
    }
}
