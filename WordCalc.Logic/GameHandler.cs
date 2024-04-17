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

    public int GetNextPlayerIndex()
    {
        // Who is the next player with the least turns?
        var playerWithLeastTurns = CurrentGame.Players.OrderBy(p => p.Turns.Count).First();
        return playerWithLeastTurns.PlayerOrder;
    }

    public void AddTurn(int playerOrder, Turn turnToAdd) =>
        CurrentGame.Players.ElementAt(playerOrder).Turns.Add(turnToAdd);

    public void ClearGame() => CurrentGame = null;
}
