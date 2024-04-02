namespace WordCalc.Logic.Tests;

[ExcludeFromCodeCoverage]
[TestFixture]
public class GameManagerTests
{
    private GameManager _gameManager;

    [SetUp]
    public void SetUp() => _gameManager = new();

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
        _gameManager.CreateGame(players);

        // Assert
        _gameManager.CurrentGame.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void AddTurn_WithValidInput_AddsTurnToCurrentGame()
    {
        // Arrange
        var players = new List<string> { "Alvin", "Jeremy" };
        _gameManager.CreateGame(players);

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
        _gameManager.AddTurn(0, new());
        _gameManager.AddTurn(1, new());
        _gameManager.AddTurn(0, new());

        // Assert
        _gameManager.CurrentGame.Should().BeEquivalentTo(expectedGame);
    }
}
