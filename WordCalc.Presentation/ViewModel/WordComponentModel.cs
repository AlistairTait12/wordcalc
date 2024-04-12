using CommunityToolkit.Mvvm.ComponentModel;
using WordCalc.Logic.Models;
using WordCalc.Presentation.Components;

namespace WordCalc.Presentation.ViewModel;

public partial class WordComponentModel : ObservableObject
{
    // TODO: Decide whether this should be a collection of TileComponentModels or Tiles.
    [ObservableProperty]
    Word word;

    [ObservableProperty]
    List<TileComponentModel> tileComponentModels;

    [ObservableProperty]
    int displayScore;

    public WordComponentModel(Word word)
    {
        Word = word;
        TileComponentModels = Word.Tiles.Select(tile => new TileComponentModel(tile)).ToList();
        TileComponentModels.ForEach(model => model.ContainingWord = this);
        DisplayScore = Word.GetValue();
    }

    internal void UpdateScore()
    {
        DisplayScore = Word.GetValue();
    }
}
