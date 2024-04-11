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
    string tileBackground;

    [ObservableProperty]
    int tileValue;

    [ObservableProperty]
    Tile tile;

    public WordComponentModel ContainingWord { get; internal set; }

    public TileComponentModel(Tile tile)
    {
        Tile = tile;
        TileValue = Tile.GetValue();
        TileBackground = GetTileBackground();
    }

    [RelayCommand]
    public void ToggleTilePremium()
    {
        SetPremium();
        UpdateTileBackground();
        UpdateTileValue();
        ContainingWord.UpdateScore();
    }

    private void SetPremium() => Tile.TilePremium = Tile.TilePremium switch
    {
        TilePremium.None => TilePremium.DoubleLetter,
        TilePremium.DoubleLetter => TilePremium.TripleLetter,
        TilePremium.TripleLetter => TilePremium.DoubleWord,
        TilePremium.DoubleWord => TilePremium.TripleWord,
        TilePremium.TripleWord => TilePremium.None,
        _ => TilePremium.None
    };

    private string GetTileBackground() => Tile.TilePremium switch
    {
        TilePremium.None => "LightGrey",
        TilePremium.DoubleLetter => "LightBlue",
        TilePremium.TripleLetter => "Blue",
        TilePremium.DoubleWord => "Yellow",
        TilePremium.TripleWord => "Red",
        _ => "LightGrey"
    };

    private void UpdateTileBackground() => TileBackground = GetTileBackground();

    public void UpdateTileValue() => TileValue = Tile.GetValue();
}
