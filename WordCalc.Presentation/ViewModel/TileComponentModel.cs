using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WordCalc.Logic;
using WordCalc.Logic.Models;

namespace WordCalc.Presentation.ViewModel;

// TODO: Should this thing have tests? Look into how to test from a Maui Project.
// TODO: Whenever the Tile changes, the WordComponentModel Will also need to update its score.
public partial class TileComponentModel : ObservableObject
{
    [ObservableProperty]
    Color tileBackground;

    [ObservableProperty]
    int tileValue;

    [ObservableProperty]
    TextDecorations tileDecoration;

    [ObservableProperty]
    Tile tile;

    public WordComponentModel ContainingWord { get; internal set; }

    public TileComponentModel(Tile tile)
    {
        Tile = tile;
        TileValue = Tile.GetValue();
        TileBackground = GetTileBackground();
        TileDecoration = GetTileDecoration();
    }

    [RelayCommand]
    public void ToggleTilePremium()
    {
        SetPremium();
        UpdateTileValue();
        UpdateTileBackground();
        ContainingWord.UpdateScore();
    }

    // TODO: Toggling the blankness of the tile

    private void SetPremium() => Tile.TilePremium = Tile.TilePremium switch
    {
        TilePremium.None => TilePremium.DoubleLetter,
        TilePremium.DoubleLetter => TilePremium.TripleLetter,
        TilePremium.TripleLetter => TilePremium.DoubleWord,
        TilePremium.DoubleWord => TilePremium.TripleWord,
        TilePremium.TripleWord => TilePremium.None,
        _ => TilePremium.None
    };

    private Color GetTileBackground() => Tile.TilePremium switch
    {
        TilePremium.None => Colors.BlanchedAlmond,
        TilePremium.DoubleLetter => Colors.LightBlue,
        TilePremium.TripleLetter => Colors.Blue,
        TilePremium.DoubleWord => Colors.Orange,
        TilePremium.TripleWord => Colors.Red,
        _ => Colors.BlanchedAlmond
    };

    private TextDecorations GetTileDecoration() => Tile.IsBlank
        ? TextDecorations.Underline
        : TextDecorations.None;

    private void UpdateTileBackground() => TileBackground = GetTileBackground();

    public void UpdateTileValue() => TileValue = Tile.GetValue();
}
