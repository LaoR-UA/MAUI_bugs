using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using TestMauiControls.Messages;

namespace TestMauiControls.ViewModels;

public partial class SecondPageViewModel : ObservableObject
{
    [RelayCommand]
    private static void SetIconState(string isActive)
    {
        var message = new IconUpdatedMessage(bool.Parse(isActive));
        StrongReferenceMessenger.Default.Send(message);
    }
    
    [RelayCommand]
    private static async Task GoBackAsync()
    {
        await Shell.Current.GoToAsync("..");
    }
}