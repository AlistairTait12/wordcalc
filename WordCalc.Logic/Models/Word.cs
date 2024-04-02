namespace WordCalc.Logic.Models;

public class Word
{
    public IEnumerable<Tile> Tiles { get; set; }

    public int GetValue()
    {
        var sum = Tiles.Sum(tile => tile.GetValue());
        var premiums = Tiles.Select(tile => tile.TilePremium);

        foreach (var premium in premiums)
        {
            if (premium is TilePremium.DoubleWord)
            {
                sum *= 2;
            }

            if (premium is TilePremium.TripleWord)
            {
                sum *= 3;
            }
        }

        return sum;
    }
}
