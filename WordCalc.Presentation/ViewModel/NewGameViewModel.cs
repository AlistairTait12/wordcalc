using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WordCalc.Logic;
using WordCalc.Presentation.View;

namespace WordCalc.Presentation.ViewModel;

public partial class NewGameViewModel : ObservableObject
{
    private GameHandler _gameHandler;

    // TODO: In a future ticket, change logic to be a list of players with a max of 4
    [ObservableProperty]
    string? player1;

    [ObservableProperty]
    string? player2;

    [ObservableProperty]
    string? player3;

    [ObservableProperty]
    string? player4;

    public NewGameViewModel(GameHandler gameHandler) => _gameHandler = gameHandler;

    [RelayCommand]
    public async Task StartGame()
    {
        var players = new List<string> { Player1, Player2, Player3, Player4 };
        var playersToUse = players.Where(p => !string.IsNullOrWhiteSpace(p)).ToList();

        _gameHandler.ClearGame();
        _gameHandler.CreateGame(playersToUse);

        await Shell.Current.GoToAsync(nameof(CurrentGamePage));
    }
}
