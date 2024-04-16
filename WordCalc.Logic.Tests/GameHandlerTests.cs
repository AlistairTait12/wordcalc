namespace WordCalc.Logic.Tests;

[ExcludeFromCodeCoverage]
[TestFixture]
public class GameHandlerTests
{
    private GameHandler _gameHandler;

    [SetUp]
    public void SetUp() => _gameHandler = new();

    [Test]
    public void CreateGame_WithPlayers_CreatesGameWithPlayers()
    {
        // Arrange
        var players = new List<string> { "Alvin", "Jeremy" };
        var expected = new Game
        {
            Players = new List<Player>
            {
                new() { Name = "Alvin", PlayerOrder = 0, Turns = [] },
                new() { Name = "Jeremy", PlayerOrder = 1, Turns = [] }
            }
        };

        // Act
        _gameHandler.CreateGame(players);

        // Assert
        _gameHandler.CurrentGame.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void AddTurn_WithValidInput_AddsTurnToCurrentGame()
    {
        // Arrange
        var players = new List<string> { "Alvin", "Jeremy" };
        _gameHandler.CreateGame(players);

        var expectedGame = new Game
        {
            Players = new List<Player>
            {
                new()
                {
                    Name = "Alvin",
                    PlayerOrder = 0,
                    Turns =
                    [
                        new Turn(),
                        new Turn()
                    ]
                },
                new()
                {
                    Name = "Jeremy",
                    PlayerOrder = 1,
                    Turns =
                    [
                        new Turn()
                    ]
                }
            }
        };

        // Act
        _gameHandler.AddTurn(0, new());
        _gameHandler.AddTurn(1, new());
        _gameHandler.AddTurn(0, new());

        // Assert
        _gameHandler.CurrentGame.Should().BeEquivalentTo(expectedGame);
    }

    [Test]
    public void ClearGame_WithCurrentGame_ClearsCurrentGame()
    {
        // Arrange
        var players = new List<string> { "Alvin", "Jeremy" };
        _gameHandler.CreateGame(players);

        // Act
        _gameHandler.ClearGame();

        // Assert
        _gameHandler.CurrentGame.Should().BeNull();
    }
}
