namespace WordCalc.Logic.Models;

public class Player
{
    public string Name { get; set; }

    public int PlayerOrder { get; set; }

    public List<Turn> Turns { get; set; }

    public int GetScore() => Turns.Sum(t => t.GetValue());
}
