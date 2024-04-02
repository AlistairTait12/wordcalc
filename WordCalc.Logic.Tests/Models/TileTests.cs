namespace WordCalc.Logic.Tests.Models;

[ExcludeFromCodeCoverage]
[TestFixture]
public class TileTests
{
    [TestCase('a', 1)]
    [TestCase('d', 2)]
    [TestCase('b', 3)]
    [TestCase('h', 4)]
    [TestCase('k', 5)]
    [TestCase('j', 8)]
    [TestCase('q', 10)]
    public void GetValue_WhenTilePremiumNone_ReturnsJustBaseValue(char letter, int expected)
    {
        // Arrange
        var tile = new Tile { Letter = letter, TilePremium = TilePremium.None };

        // Assert
        tile.GetValue().Should().Be(expected);
    }

    [TestCase('A', 1)]
    [TestCase('B', 3)]
    public void GetValue_WithCapitalLetter_ReturnsSameValue(char letter, int expected)
    {
        // Arrange
        var tile = new Tile { Letter = letter, TilePremium = TilePremium.None };

        // Assert
        tile.GetValue().Should().Be(expected);
    }

    [TestCase('a', 2)]
    [TestCase('d', 4)]
    [TestCase('b', 6)]
    [TestCase('h', 8)]
    [TestCase('k', 10)]
    [TestCase('j', 16)]
    [TestCase('q', 20)]
    public void GetValue_WhenTilePremiumDoubleLetter_ReturnsDoubleBaseValue(char letter, int expected)
    {
        // Arrange
        var tile = new Tile { Letter = letter, TilePremium = TilePremium.DoubleLetter };

        // Assert
        tile.GetValue().Should().Be(expected);
    }

    [TestCase('a', 3)]
    [TestCase('d', 6)]
    [TestCase('b', 9)]
    [TestCase('h', 12)]
    [TestCase('k', 15)]
    [TestCase('j', 24)]
    [TestCase('q', 30)]
    public void GetValue_WhenTilePremiumTripleLetter_ReturnsTripleBaseValue(char letter, int expected)
    {
        // Arrange
        var tile = new Tile { Letter = letter, TilePremium = TilePremium.TripleLetter };

        // Assert
        tile.GetValue().Should().Be(expected);
    }

    [TestCase('a', 1)]
    [TestCase('d', 2)]
    [TestCase('b', 3)]
    [TestCase('h', 4)]
    [TestCase('k', 5)]
    [TestCase('j', 8)]
    [TestCase('q', 10)]
    public void GetValue_WhenTilePremiumDoubleWord_ReturnsJustBaseValue(char letter, int expected)
    {
        // Arrange
        var tile = new Tile { Letter = letter, TilePremium = TilePremium.DoubleWord };

        // Assert
        tile.GetValue().Should().Be(expected);
    }

    [TestCase('a', 1)]
    [TestCase('d', 2)]
    [TestCase('b', 3)]
    [TestCase('h', 4)]
    [TestCase('k', 5)]
    [TestCase('j', 8)]
    [TestCase('q', 10)]
    public void GetValue_WhenTilePremiumTripleWordsJustBaseValue(char letter, int expected)
    {
        // Arrange
        var tile = new Tile { Letter = letter, TilePremium = TilePremium.TripleWord };

        // Assert
        tile.GetValue().Should().Be(expected);
    }

    [TestCase('a', TilePremium.None)]
    [TestCase('d', TilePremium.DoubleLetter)]
    [TestCase('b', TilePremium.TripleLetter)]
    [TestCase('h', TilePremium.DoubleWord)]
    [TestCase('k', TilePremium.TripleWord)]
    public void GetValue_WhenIsBlank_ReturnsZero(char letter, TilePremium premium)
    {
        // Arrange
        var tile = new Tile { Letter = letter, IsBlank = true, TilePremium = premium };

        // Assert
        tile.GetValue().Should().Be(0);
    }
}
