using CommunityToolkit.Mvvm.ComponentModel;
using WordCalc.Logic;

namespace WordCalc.Presentation.ViewModel;

public partial class ScoresViewModel : ObservableObject
{
    private readonly GameHandler _gameHandler;

    [ObservableProperty]
    int numberOfPlayers;

    public ScoresViewModel(GameHandler gameHandler) => _gameHandler = gameHandler;
}
