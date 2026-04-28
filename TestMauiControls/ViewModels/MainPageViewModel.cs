using System.Diagnostics;
using System.Windows.Input;

namespace TestMauiControls.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand NavigateToSecondPageCommand { get; } = new Command(async () =>
        {
            try
            {
                StaticDataContainer.Invocations.Clear();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exception while clearing invocations: {e.Message}");
            }
            await Shell.Current.GoToAsync(StaticDataContainer.SecondPageRoute, new Dictionary<string, object>
            {
                { "goUpFrom1", 1 }
            });
        });
    }
}
