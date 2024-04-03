using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WordCalc.Logic;

namespace WordCalc.Presentation.ViewModel;

public partial class NewGameViewModel : ObservableObject
{
    private GameHandler _gameHandler;

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
    public void StartGame()
    {
        var players = new List<string> { Player1, Player2, Player3, Player4 };
        var playersToUse = players.Where(p => !string.IsNullOrWhiteSpace(p)).ToList();

        _gameHandler.ClearGame();
        _gameHandler.CreateGame(playersToUse);

        // TODO: Navigate to the game page
    }
}
