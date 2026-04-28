using System.Windows.Input;

namespace TestMauiControls.ViewModels
{
    public class ThirdPageViewModel : BaseViewModel
    {
        public ICommand GoBackCommand { get; } = new Command(async () =>
        {
            await Shell.Current.GoToAsync("..?callbackFrom3=3");
        });
    }
}
