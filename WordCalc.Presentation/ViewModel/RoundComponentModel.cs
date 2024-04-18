using CommunityToolkit.Mvvm.ComponentModel;

namespace WordCalc.Presentation.ViewModel;

public partial class RoundComponentModel : ObservableObject
{
    [ObservableProperty]
    int roundNumber;

    [ObservableProperty]
    List<PlayerTurnComponentModel> playerTurns;
}
