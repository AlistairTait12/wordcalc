using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WordCalc.Logic.ModelBuilder;
using WordCalc.Logic.Models;

namespace WordCalc.Presentation.ViewModel;

public partial class TestViewModel : ObservableObject
{
    private readonly TileListBuilder _tileListBuilder;

    [ObservableProperty]
    ObservableCollection<WordComponentModel> wordComponentModelList;

    [ObservableProperty]
    string wordEntryText;

    public TestViewModel()
    {
        _tileListBuilder = new();
        WordComponentModelList = new();
    }

    [RelayCommand]
    public void AddWord()
    {
        var tiles = _tileListBuilder.Build(WordEntryText.ToUpper());
        var word = new Word() { Tiles = tiles.ToList()};
        var wordComponentModel = new WordComponentModel(word);
        WordComponentModelList.Add(wordComponentModel);
        WordEntryText = string.Empty;
    }
}
