using WordCalc.Logic.Models;

namespace WordCalc.Logic;

public class GameManager
{
    public Game? CurrentGame { get; private set; }

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

    public void AddTurn(int playerOrder, Turn turnToAdd) =>
        CurrentGame.Players.ElementAt(playerOrder).Turns.Add(turnToAdd);
}
