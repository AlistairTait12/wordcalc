using WordCalc.Logic.Models;

namespace WordCalc.Logic;

public class GameHandler
{
    public Game? CurrentGame { get; set; }

    public void CreateGame(IEnumerable<string> players)
    {
        CurrentGame = new();
        var playersToAdd = new List<Player>();
        for (int i = 0; i < players.Count(); i++)
        {
            playersToAdd.Add(new() { Name = players.ElementAt(i), PlayerOrder = i });
        }

        CurrentGame.Players = playersToAdd;

        foreach (var player in CurrentGame.Players)
        {
            player.Turns = [];
        }
    }

    public int GetNextPlayerIndex() =>
        CurrentGame.Players.OrderBy(p => p.Turns.Count).First().PlayerOrder;

    public void AddTurn(int playerOrder, Turn turnToAdd) =>
        CurrentGame.Players.ElementAt(playerOrder).Turns.Add(turnToAdd);

    public void ClearGame() => CurrentGame = null;
}
