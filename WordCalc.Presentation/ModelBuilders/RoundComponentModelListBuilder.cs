using System.Collections.ObjectModel;
using WordCalc.Logic.Models;
using WordCalc.Presentation.ViewModel;

namespace WordCalc.Presentation.ModelBuilders;

public class RoundComponentModelListBuilder
{
    public ObservableCollection<RoundComponentModel> BuildRoundComponents(Game game)
    {
        var maxTurns = game.Players.Max(p => p.Turns.Count);
        var roundComponents = new ObservableCollection<RoundComponentModel>();

        for (var i = 0; i < maxTurns; i++)
        {
            var roundComponent = new RoundComponentModel
            {
                RoundNumber = i + 1,
                PlayerTurns = new ()
            };

            foreach (var player in game.Players)
            {
                if (player.Turns.Count > i)
                {
                    var turn = player.Turns[i];
                    var playerTurnComponentModel = new PlayerTurnComponentModel
                    {
                        PlayerName = player.Name,
                        Words = GetCommaSeparatedWords(turn.Words),
                        TurnScore = turn.GetValue(),
                        CumulativeScore = player.Turns.Take(i + 1).Sum(t => t.GetValue())
                    };
                    roundComponent.PlayerTurns.Add(playerTurnComponentModel);
                }
            }
            roundComponents.Add(roundComponent);
        }

        return roundComponents;
    }

    private string GetCommaSeparatedWords(IEnumerable<Word> words)
    {
        var wordList = new List<string>();
        foreach (var word in words)
        {
            var wordString = string.Join(string.Empty, word.Tiles.Select(tile => tile.Letter));
            wordList.Add(wordString);
        }
        return string.Join(", ", wordList).TrimEnd();
    }
}
