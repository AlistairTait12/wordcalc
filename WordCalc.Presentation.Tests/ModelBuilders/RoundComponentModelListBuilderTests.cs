using FluentAssertions;
using System.Diagnostics.CodeAnalysis;
using WordCalc.Logic.Models;
using WordCalc.Presentation.ModelBuilders;
using WordCalc.Presentation.ViewModel;

namespace WordCalc.Presentation.Tests.ModelBuilders;

[ExcludeFromCodeCoverage]
[TestFixture]
public class RoundComponentModelListBuilderTests
{
    [Test]
    public void BuildRoundComponents_WhenCalled_ReturnsObservableCollectionOfRoundComponentModel()
    {
        // Arrange
        var game = new Game()
        {
            Players =
            [
                new ()
                {
                    Name = "Dave",
                    PlayerOrder = 1,
                    Turns =
                    [
                        new () { Words = [CreateWord("apple") ] },
                        new () { Words = [CreateWord("grape") ] },
                    ]
                },
                new ()
                {
                    Name = "Kim",
                    PlayerOrder = 2,
                    Turns =
                    [
                        new () { Words = [CreateWord("banana") ] },
                    ]
                }
            ]
        };

        var expected = new List<RoundComponentModel>
        {
            new ()
            {
                RoundNumber = 1,
                PlayerTurns =
                [
                    new () { PlayerName = "Dave", Words = "apple", TurnScore = 9, CumulativeScore = 9 },
                    new () { PlayerName = "Kim", Words = "banana", TurnScore = 8, CumulativeScore = 8 }
                ]
            },
            new ()
            {
                RoundNumber = 2,
                PlayerTurns =
                [
                    new () { PlayerName = "Dave", Words = "grape", TurnScore = 8, CumulativeScore = 17 }
                ]
            }
        };

        var roundComponentModelListBuilder = new RoundComponentModelListBuilder();

        // Act
        var actual = roundComponentModelListBuilder.BuildRoundComponents(game);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    // Untested logic in the tests. Yikes. \_(o_O)_/
    private static Word CreateWord(string input) => new ()
    {
        Tiles = input.Select(c => new Tile { Letter = c }).ToList()
    };
}
