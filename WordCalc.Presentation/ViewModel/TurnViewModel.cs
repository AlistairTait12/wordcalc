using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using WordCalc.Logic;
using WordCalc.Logic.ModelBuilder;
using WordCalc.Logic.Models;
using WordCalc.Presentation.View;

namespace WordCalc.Presentation.ViewModel;

public partial class TurnViewModel : ObservableObject, IQueryAttributable
{
    private readonly TileListBuilder _tileListBuilder;
    private readonly GameHandler _gameHandler;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(UpdateTurnDisplayScoreCommand))]
    ObservableCollection<WordComponentModel> wordComponentModelList;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(UpdateAddWordButtonStateCommand))]
    string wordEntryText = string.Empty;

    [ObservableProperty]
    bool isAddWordButtonEnabled = false;

    [ObservableProperty]
    int turnDisplayScore;

    [ObservableProperty]
    Turn turn;

    public TurnViewModel(GameHandler gameHandler)
    {
        _gameHandler = gameHandler;
        _tileListBuilder = new();
        WordComponentModelList = new();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Turn = query["Turn"] as Turn;
    }

    [RelayCommand]
    public void AddWord()
    {
        var tiles = _tileListBuilder.Build(WordEntryText.ToUpper());
        var word = new Word() { Tiles = tiles.ToList()};
        Turn.Words.Add(word);
        var wordComponentModel = new WordComponentModel(word);
        WordComponentModelList.Add(wordComponentModel);
        WordComponentModelList.Last().ContainingTurn = this;
        WordEntryText = string.Empty;
        UpdateTurnDisplayScore();
    }

    partial void OnWordEntryTextChanged(string value) => UpdateAddWordButtonState();

    [RelayCommand]
    private void UpdateAddWordButtonState()
    {
        string pattern = @"^([A-Za-z]{1}_{0,1}[23\+\*]{0,1})+$";
        bool isMatch = Regex.IsMatch(WordEntryText, pattern);
        IsAddWordButtonEnabled = isMatch;
    }

    // TODO: This needs to be called whenever a word is added or removed or when a tile is toggled.
    // TODO: Surely there has to be a better way than explicitly calling it every time
    [RelayCommand]
    public void UpdateTurnDisplayScore() => TurnDisplayScore = Turn.GetValue();

    [RelayCommand]
    public void AddTurnToGame()
    {
        _gameHandler.AddTurn(0, Turn);
        Shell.Current.GoToAsync(nameof(CurrentGamePage), true);
    }
}
