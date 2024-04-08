using System.Text.RegularExpressions;
using WordCalc.Logic.Models;

namespace WordCalc.Logic.ModelBuilder;

public class TileListBuilder
{
    private const string _validTilePattern = @"[A-Za-z]{1}_{0,1}[23\+\*]{0,1}";

    public IEnumerable<Tile> Build(string tileNotation)
    {
        ValidateNotation(tileNotation);

        return Regex.Matches(tileNotation, _validTilePattern)
            .ToList()
            .Select(GetTileFromMatch);
    }

    private static void ValidateNotation(string tileNotation)
    {
        var validWordPattern = @$"^({_validTilePattern})+$";
        if (!Regex.IsMatch(tileNotation, validWordPattern))
        {
            throw new ArgumentException($"{tileNotation} is not valid notation");
        }
    }

    private static Tile GetTileFromMatch(Match match)
    {
        var premium = Regex.Match(match.Value, @"[23\+\*]{1}").Value;
        var tilePremium = premium switch
        {
            "" => TilePremium.None,
            "2" => TilePremium.DoubleLetter,
            "3" => TilePremium.TripleLetter,
            "+" => TilePremium.DoubleWord,
            "*" => TilePremium.TripleWord,
            _ => throw new ArgumentException($"{match.Value} is not valid notation")
        };

        return new Tile
        {
            Letter = match.Value[0],
            IsBlank = match.Value.Contains('_'),
            TilePremium = tilePremium
        };
    }
}
