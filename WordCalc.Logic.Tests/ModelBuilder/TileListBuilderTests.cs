using WordCalc.Logic.ModelBuilder;

namespace WordCalc.Logic.Tests.ModelBuilder;

[ExcludeFromCodeCoverage]
[TestFixture]
public class TileListBuilderTests
{
    private TileListBuilder _builder;

    [SetUp]
    public void Setup() => _builder = new TileListBuilder();

    [Test]
    public void BuildWithSimpleWordReturnsTileList()
    {
        // Arrange
        var expectedTiles = new List<Tile>
        {
            new () { Letter = 'a' },
            new () { Letter = 'p' },
            new () { Letter = 'p' },
            new () { Letter = 'l' },
            new () { Letter = 'e' }
        };

        // Act
        var actual = _builder.Build("apple");

        // Assert
        actual.Should().BeEquivalentTo(expectedTiles, options => options.WithStrictOrdering());
    }

    [Test]
    public void BuildWithTileNotationReturnsTileList()
    {
        // Arrange
        var expectedTiles = new List<Tile>
        {
            new () { Letter = 'a', TilePremium = TilePremium.DoubleLetter },
            new () { Letter = 'p' },
            new () { Letter = 'p' },
            new () { Letter = 'l', TilePremium = TilePremium.TripleLetter },
            new () { Letter = 'e' }
        };

        // Act
        var actual = _builder.Build("a2ppl3e");

        // Assert
        actual.Should().BeEquivalentTo(expectedTiles, options => options.WithStrictOrdering());
    }

    [Test]
    public void BuildWithTileNotationContainingBlankLetterReturnsWord()
    {
        // Of course in a real board, you wouldn't find these squares in this order
        // Arrange
        var expectedTiles = new List<Tile>
        {
            new () { Letter = 'a', TilePremium = TilePremium.DoubleLetter },
            new () { Letter = 'p', IsBlank = true, TilePremium = TilePremium.DoubleWord },
            new () { Letter = 'p' },
            new () { Letter = 'l', TilePremium = TilePremium.TripleLetter },
            new () { Letter = 'e' }
        };

        // Act
        var actual = _builder.Build("a2p_+pl3e");

        // Assert
        actual.Should().BeEquivalentTo(expectedTiles, options => options.WithStrictOrdering());
    }

    [TestCase("appl!e")]
    [TestCase("ban23ana")]
    [TestCase("ora__nge")]
    [TestCase("no spaces")]
    [TestCase("")]
    public void BuildWithInvalidNotationThrowsInvalidArgumentException(string input)
    {
        // Act
        var act = () => _builder.Build(input);

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage($"{input} is not valid notation");
    }
}
