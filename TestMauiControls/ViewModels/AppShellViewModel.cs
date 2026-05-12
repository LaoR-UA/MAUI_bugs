using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using TestMauiControls.Messages;

namespace TestMauiControls.ViewModels;

public partial class AppShellViewModel : ObservableObject, IDisposable
{
    [ObservableProperty]
    private ImageSource? flyoutIcon;

    private static readonly ImageSource NotificationMenuIcon = ImageSource.FromFile("icon_colorful.png");
    private bool isRootPageDisplayed = true;

    public AppShellViewModel()
    {
        bool isRegistered = StrongReferenceMessenger.Default.IsRegistered<IconUpdatedMessage>(this);
        if (!isRegistered)
        {
            StrongReferenceMessenger.Default.Register<IconUpdatedMessage>(this, (viewModel, message) =>
            {
                if (viewModel is AppShellViewModel appShellViewModal)
                {
                    appShellViewModal.IconHasChanged = message.Value;
                    appShellViewModal.FlyoutIcon = IsRootPageDisplayed && message.Value ? NotificationMenuIcon : null;
                }
            });
        }
    }

    public bool IconHasChanged { get; set; }

    public bool IsRootPageDisplayed
    {
        get => isRootPageDisplayed;
        set
        {
            if (isRootPageDisplayed == value)
                return;
            isRootPageDisplayed = value;
            FlyoutIcon = IsRootPageDisplayed && IconHasChanged ? NotificationMenuIcon : null;
        }
    }

    public void Dispose()
    {
        StrongReferenceMessenger.Default.Unregister<IconUpdatedMessage>(this);
        GC.SuppressFinalize(this);
    }
}
