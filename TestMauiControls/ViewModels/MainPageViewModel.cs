using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TestMauiControls.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    [RelayCommand]
    private static async Task GoToSubPageAsync()
    {
        await Shell.Current.GoToAsync("secondPage");
    }
}