namespace WordCalc.Logic.Models;

public class Tile
{
    public char Letter { get; set; }

    public bool IsBlank { get; set; } = false;

    public TilePremium TilePremium { get; set; }

    public int GetValue()
    {
        if (IsBlank)
        {
            return 0;
        }

        var baseValue = LetterValueProvider.GetLetterBaseValue(Letter);

        if (TilePremium is TilePremium.DoubleLetter)
        {
            return baseValue * 2;
        }

        if (TilePremium is TilePremium.TripleLetter)
        {
            return baseValue * 3;
        }

        return baseValue;
    }
}
