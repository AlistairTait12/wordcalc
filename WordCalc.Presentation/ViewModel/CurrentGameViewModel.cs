using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WordCalc.Logic;
using WordCalc.Logic.Models;
using WordCalc.Presentation.ModelBuilders;
using WordCalc.Presentation.View;

namespace WordCalc.Presentation.ViewModel;

public partial class CurrentGameViewModel : ObservableObject
{
    private readonly GameHandler _gameHandler;
    private readonly RoundComponentModelListBuilder _roundComponentModelListBuilder;

    public CurrentGameViewModel(GameHandler gameHandler,
        RoundComponentModelListBuilder roundComponentModelListBuilder)
    {
        _gameHandler = gameHandler;
        _roundComponentModelListBuilder = roundComponentModelListBuilder;
        rounds = _roundComponentModelListBuilder.BuildRoundComponents(_gameHandler.CurrentGame);
    }

    [ObservableProperty]
    ObservableCollection<RoundComponentModel> rounds;

    [RelayCommand]
    public async Task AddTurn()
    {
        // TODO: Maybe the player index should be moved to the TurnPage
        var playerIndex = _gameHandler.GetNextPlayerIndex();
        _gameHandler.AddTurn(playerIndex, new Turn());
        var turn = _gameHandler.CurrentGame.Players.ElementAt(playerIndex).Turns.Last();
        await Shell.Current.GoToAsync(nameof(TurnPage), true,
            new Dictionary<string, object>
            {
                { "Turn", turn }
            });
    }

    // TODO: Add a command to edit a turn, this would pass in the turn to edit
}
