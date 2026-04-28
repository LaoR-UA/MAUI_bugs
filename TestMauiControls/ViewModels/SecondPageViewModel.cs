using System.Windows.Input;

namespace TestMauiControls.ViewModels
{
    public class SecondPageViewModel : BaseViewModel
    {
        public ICommand NavigateToThirdPageCommand { get; } = new Command(async () =>
        {
            await Shell.Current.GoToAsync(StaticDataContainer.ThirdPageRoute, new Dictionary<string, object>
            {
                { "goUpFrom2", 2 }
            });
        });
        public ICommand GoBackCommand { get; } = new Command(async () =>
        {
            await Shell.Current.GoToAsync("..?callbackFrom2=2");
        });
    }
}
