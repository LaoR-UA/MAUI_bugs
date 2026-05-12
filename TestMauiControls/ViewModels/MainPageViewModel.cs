using System.Diagnostics;
using System.Windows.Input;

namespace TestMauiControls.ViewModels
{
    public class MainPageViewModel : IQueryAttributable
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

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var item = $"{GetType().Name}.ApplyQueryAttributes: {string.Join(" ;", query)}";
            try
            {
                StaticDataContainer.Invocations.Add(item);
            }
            catch (Exception exception)
            {
                // Sometimes the UI thread is not read to handle collection changes, so we catch the exception and log it instead of crashing the app.
                Debug.WriteLine(
                    $"Exception while adding invocation: {exception.Message} ; item: {item} ;");
            }
        }
    }
}
