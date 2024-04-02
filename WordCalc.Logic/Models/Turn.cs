namespace WordCalc.Logic.Models;

public class Turn
{
    public IEnumerable<Word> Words { get; set; }

    public bool HasBonus { get; set; } = false;

    public int GetValue()
    {
        var total = Words.Sum(w => w.GetValue());

        if (HasBonus)
        {
            total += 50;
        }

        return total;
    }
}
