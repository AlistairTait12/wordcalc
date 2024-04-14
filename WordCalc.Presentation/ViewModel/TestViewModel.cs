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
    [NotifyCanExecuteChangedFor(nameof(UpdateAddWordButtonStateCommand))]
    string wordEntryText = string.Empty;

    [ObservableProperty]
    bool isAddWordButtonEnabled = false;

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

    partial void OnWordEntryTextChanged(string value) => UpdateAddWordButtonState();

    [RelayCommand]
    private void UpdateAddWordButtonState()
    {
        // Get the regular expression pattern from TileListBuilder
        // @$"^({_validTilePattern})+$"
        string pattern = @"^([A-Za-z]{1}_{0,1}[23\+\*]{0,1})+$";

        // Check if WordEntryText matches the regular expression pattern
        bool isMatch = System.Text.RegularExpressions.Regex.IsMatch(WordEntryText, pattern);

        // Update the IsAddWordButtonEnabled property based on the match result
        IsAddWordButtonEnabled = isMatch;
    }
}
