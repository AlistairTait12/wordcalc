namespace WordCalc.Logic.Tests.Models;

[ExcludeFromCodeCoverage]
[TestFixture]
public class WordTests
{
    [Test]
    public void GetValue_WhenWordPremiumNone_ReturnsSumOfTileValues()
    {
        // Arrange
        var tiles = new List<Tile>
        {
            new() { Letter = 'a', TilePremium = TilePremium.None },
            new() { Letter = 'p', TilePremium = TilePremium.DoubleLetter },
            new() { Letter = 'p', TilePremium = TilePremium.None },
            new() { Letter = 'l', TilePremium = TilePremium.DoubleLetter },
            new() { Letter = 'e', TilePremium = TilePremium.None }
        };

        var word = new Word { Tiles = tiles };

        // Act
        var actual = word.GetValue();

        // Assert
        actual.Should().Be(13);
    }

    [Test]
    public void GetValue_WhenOneWordPremiumDouble_ReturnsDoubleSumOfTileValues()
    {
        // Arrange
        var tiles = new List<Tile>
        {
            new() { Letter = 'a', TilePremium = TilePremium.DoubleLetter },
            new() { Letter = 'p', TilePremium = TilePremium.None },
            new() { Letter = 'p', TilePremium = TilePremium.None },
            new() { Letter = 'l', TilePremium = TilePremium.DoubleWord },
            new() { Letter = 'e', TilePremium = TilePremium.None }
        };

        var word = new Word { Tiles = tiles };

        // Act
        var actual = word.GetValue();

        // Assert
        actual.Should().Be(20);
    }

    [Test]
    public void GetValue_WhenOneWordPremiumTriple_ReturnsTripleSumOfTileValues()
    {
        // Arrange
        var tiles = new List<Tile>
        {
            new() { Letter = 'z', TilePremium = TilePremium.DoubleLetter },
            new() { Letter = 'o', TilePremium = TilePremium.None },
            new() { Letter = 'n', TilePremium = TilePremium.None },
            new() { Letter = 'e', TilePremium = TilePremium.None },
            new() { Letter = 's', TilePremium = TilePremium.TripleWord },
        };

        var word = new Word { Tiles = tiles };

        // Act
        var actual = word.GetValue();

        // Assert
        actual.Should().Be(72);
    }

    [Test]
    public void GetValue_WhenTwoWordPremiumDouble_ReturnsQuadrupleSumOfTileValues()
    {
        // Arrange
        var tiles = new List<Tile>
        {
            new() { Letter = 'r', TilePremium = TilePremium.DoubleWord },
            new() { Letter = 'i', TilePremium = TilePremium.None },
            new() { Letter = 'o', TilePremium = TilePremium.None },
            new() { Letter = 't', TilePremium = TilePremium.None },
            new() { Letter = 'o', TilePremium = TilePremium.None },
            new() { Letter = 'u', TilePremium = TilePremium.None },
            new() { Letter = 's', TilePremium = TilePremium.DoubleWord }
        };

        var word = new Word { Tiles = tiles };

        // Act
        var actual = word.GetValue();

        // Assert
        actual.Should().Be(28);
    }

    [Test]
    public void GetValue_WhenTwoWordPremiumTriple_ReturnsNineTimesSumOfTileValues()
    {
        // Arrange
        var tiles = new List<Tile>
        {
            new() { Letter = 'j', TilePremium = TilePremium.TripleWord },
            new() { Letter = 'u', TilePremium = TilePremium.None },
            new() { Letter = 'v', TilePremium = TilePremium.None },
            new() { Letter = 'e', TilePremium = TilePremium.DoubleLetter },
            new() { Letter = 'n', TilePremium = TilePremium.None },
            new() { Letter = 'i', TilePremium = TilePremium.None },
            new() { Letter = 'l', TilePremium = TilePremium.None },
            new() { Letter = 'e', TilePremium = TilePremium.TripleWord }
        };

        var word = new Word { Tiles = tiles };

        // Act
        var actual = word.GetValue();

        // Assert
        actual.Should().Be(171);
    }
}
