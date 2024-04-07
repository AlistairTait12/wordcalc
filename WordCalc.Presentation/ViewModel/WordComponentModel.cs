using CommunityToolkit.Mvvm.ComponentModel;
using WordCalc.Presentation.Components;

namespace WordCalc.Presentation.ViewModel;

public partial class WordComponentModel : ObservableObject
{
    [ObservableProperty]
    IEnumerable<TileComponent> tileCollection;

    public WordComponentModel()
    {
        tileCollection = new List<TileComponent>();
    }
}
