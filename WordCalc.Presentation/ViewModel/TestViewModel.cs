using CommunityToolkit.Mvvm.ComponentModel;
using WordCalc.Logic.Models;

namespace WordCalc.Presentation.ViewModel;

public partial class TestViewModel : ObservableObject
{
    [ObservableProperty]
    List<WordComponentModel> wordComponentModelList;

    public TestViewModel()
    {
        var words = new List<Word>
        {
            new()
            {
                Tiles = new List<Tile>
                {
                    new() { Letter = 'A' },
                    new() { Letter = 'P' },
                    new() { Letter = 'P' },
                    new() { Letter = 'L' },
                    new() { Letter = 'E' }
                }
            },
            new()
            {
                Tiles = new List<Tile>
                {
                    new() { Letter = 'A' },
                    new() { Letter = 'P' },
                    new() { Letter = 'P' },
                    new() { Letter = 'L' },
                    new() { Letter = 'E' }
                }
            }
        };

        WordComponentModelList = words.Select(word => new WordComponentModel(word)).ToList();
    }
}
