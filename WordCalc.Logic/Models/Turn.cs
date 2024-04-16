namespace WordCalc.Logic.Models;

public class Turn
{
    public List<Word> Words { get; set; } = new();

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
