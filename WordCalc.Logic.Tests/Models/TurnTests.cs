namespace WordCalc.Logic.Tests.Models;

[ExcludeFromCodeCoverage]
[TestFixture]
public class TurnTests
{
    [Test]
    public void GetValue_WhenNoWords_ReturnsZero()
    {
        // Arrange
        var turn = new Turn { Words = new List<Word>() };

        // Act
        var actual = turn.GetValue();

        // Assert
        actual.Should().Be(0);
    }

    [Test]
    public void GetValue_WhenOneWord_ReturnsWordValue()
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

        var turn = new Turn { Words = new List<Word> { word } };

        // Act
        var actual = turn.GetValue();

        // Assert
        actual.Should().Be(13);
    }

    [Test]
    public void GetValue_WhenTwoWords_ReturnsSumOfWordValues()
    {
        // Arrange
        var tiles1 = new List<Tile>
        {
            new() { Letter = 'a', TilePremium = TilePremium.None },
            new() { Letter = 'p', TilePremium = TilePremium.DoubleLetter },
            new() { Letter = 'p', TilePremium = TilePremium.None },
            new() { Letter = 'l', TilePremium = TilePremium.DoubleLetter },
            new() { Letter = 'e', TilePremium = TilePremium.None }
        };

        var word1 = new Word { Tiles = tiles1 };

        var tiles2 = new List<Tile>
        {
            new() { Letter = 'z', TilePremium = TilePremium.DoubleLetter },
            new() { Letter = 'o', TilePremium = TilePremium.None },
            new() { Letter = 'o', TilePremium = TilePremium.None },
            new() { Letter = 'm', TilePremium = TilePremium.DoubleLetter }
        };

        var word2 = new Word { Tiles = tiles2 };

        var turn = new Turn { Words = new List<Word> { word1, word2 } };

        // Act
        var actual = turn.GetValue();

        // Assert
        actual.Should().Be(41);
    }

    [Test]
    public void GetValue_WhenOneSevenTileWordWithBonus_ReturnsWordValuePlusFifty()
    {
        // Arrange
        var tiles = new List<Tile>
        {
            new() { Letter = 'a', TilePremium = TilePremium.None },
            new() { Letter = 'm', TilePremium = TilePremium.None },
            new() { Letter = 'a', TilePremium = TilePremium.None },
            new() { Letter = 'z', TilePremium = TilePremium.DoubleLetter },
            new() { Letter = 'i', TilePremium = TilePremium.None },
            new() { Letter = 'n', TilePremium = TilePremium.None },
            new() { Letter = 'g', TilePremium = TilePremium.None }
        };

        var word = new Word { Tiles = tiles };

        var turn = new Turn { Words = new List<Word> { word }, HasBonus = true };

        // Act
        var actual = turn.GetValue();

        // Assert
        actual.Should().Be(79);
    }

    [Test]
    public void GetValue_WhenOneSevenTileWordAndNormalWordWithBonus_ReturnsWordValuePlusFifty()
    {
        // Arrange
        var tiles = new List<Tile>
        {
            new() { Letter = 'a', TilePremium = TilePremium.None },
            new() { Letter = 'm', TilePremium = TilePremium.None },
            new() { Letter = 'a', TilePremium = TilePremium.None },
            new() { Letter = 'z', TilePremium = TilePremium.DoubleLetter },
            new() { Letter = 'i', TilePremium = TilePremium.None },
            new() { Letter = 'n', TilePremium = TilePremium.None },
            new() { Letter = 'g', TilePremium = TilePremium.None }
        };
        
        var word1 = new Word { Tiles = tiles };

        var tiles2 = new List<Tile>
        {
            new() { Letter = 'g', TilePremium = TilePremium.None},
            new() { Letter = 'e', TilePremium = TilePremium.DoubleWord},
            new() { Letter = 'n', TilePremium = TilePremium.None},
            new() { Letter = 'i', TilePremium = TilePremium.None},
            new() { Letter = 'u', TilePremium = TilePremium.None},
            new() { Letter = 's', TilePremium = TilePremium.None}
        };

        var word2 = new Word { Tiles = tiles2 };

        var turn = new Turn { Words = new List<Word> { word1, word2 }, HasBonus = true };

        // Act
        var actual = turn.GetValue();

        // Assert
        actual.Should().Be(93);
    }
}
