using WordCalc.Presentation.ViewModel;

namespace WordCalc.Presentation.Components;

public partial class TileComponent : ContentView
{
    public TileComponent()
    {
        InitializeComponent();
        BindingContext = new TileComponentModel();
    }
}
