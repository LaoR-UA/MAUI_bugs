using System.Diagnostics;
using System.Windows.Input;

namespace TestMauiControls.ViewModels;

public class SecondPageViewModel : IQueryAttributable
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