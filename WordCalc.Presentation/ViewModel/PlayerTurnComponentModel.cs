using CommunityToolkit.Mvvm.ComponentModel;

namespace WordCalc.Presentation.ViewModel;

public partial class PlayerTurnComponentModel : ObservableObject
{
    [ObservableProperty]
    string playerName;

    [ObservableProperty]
    string words;

    [ObservableProperty]
    int turnScore;

    [ObservableProperty]
    int cumulativeScore;
}
