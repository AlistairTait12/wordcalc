namespace WordCalc.Logic.Tests.Models;

[ExcludeFromCodeCoverage]
[TestFixture]
public class PlayerTests
{
    [Test]
    public void GetScore_NoTurns_ReturnsZero()
    {
        // Arrange
        var player = new Player { Name = "Alvin", PlayerOrder = 1, Turns = new List<Turn>() };

        // Act
        var actual = player.GetScore();

        // Assert
        actual.Should().Be(0);
    }

    [Test]
    public void GetScore_OneTurn_ReturnsSumOfTurn()
    {
        // Arrange
        var player = new Player { Name = "Alvin", PlayerOrder = 1 };

        var tiles = new List<Tile>
        {
            new () { Letter = 'z' },
            new () { Letter = 'o' },
            new () { Letter = 'o' },
            new () { Letter = 'm' }
        };

        var word = new Word { Tiles = tiles };
        var turn = new Turn { Words = new List<Word> { word } };
        player.Turns = new List<Turn> { turn };

        // Act
        var actual = player.GetScore();

        // Assert
        actual.Should().Be(15);
    }

    [Test]
    public void GetScore_TwoTurns_ReturnsSumOfTurns()
    {
        // Arrange
        var player = new Player { Name = "Alvin", PlayerOrder = 1 };

        var tiles1 = new List<Tile>
        {
            new () { Letter = 'z' },
            new () { Letter = 'o' },
            new () { Letter = 'o' },
            new () { Letter = 'm' }
        };

        var word1 = new Word { Tiles = tiles1 };
        var turn1 = new Turn { Words = new List<Word> { word1 } };

        var tiles2 = new List<Tile>
        {
            new () { Letter = 'c' },
            new () { Letter = 'a' },
            new () { Letter = 't' }
        };

        var word2 = new Word { Tiles = tiles2 };
        var turn2 = new Turn { Words = new List<Word> { word2 } };

        player.Turns = new List<Turn> { turn1, turn2 };

        // Act
        var actual = player.GetScore();

        // Assert
        actual.Should().Be(20);
    }
}
