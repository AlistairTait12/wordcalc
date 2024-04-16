using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WordCalc.Logic.Models;

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

    public TestViewModel ContainingTurn { get; internal set; }

    public WordComponentModel(Word word)
    {
        Word = word;
        TileComponentModels = Word.Tiles.Select(tile => new TileComponentModel(tile)).ToList();
        TileComponentModels.ForEach(model => model.ContainingWord = this);
        DisplayScore = Word.GetValue();
    }

    [RelayCommand]
    public void RemoveWord()
    {
        ContainingTurn.Turn.Words.Remove(Word);
        ContainingTurn.WordComponentModelList.Remove(this);
        ContainingTurn.UpdateTurnDisplayScore();
    }

    internal void UpdateScore()
    {
        DisplayScore = Word.GetValue();
        ContainingTurn.UpdateTurnDisplayScore();
    }
}
