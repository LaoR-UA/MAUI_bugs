using TestMauiControls.ViewModels;

namespace TestMauiControls;

public partial class AppShell
{
    private readonly AppShellViewModel pageViewModel;
    private bool shellInitialized;

    public AppShell(AppShellViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        pageViewModel = viewModel;
        shellInitialized = true;
    }

    protected override void OnNavigating(ShellNavigatingEventArgs args)
    {
        base.OnNavigating(args);
        if (shellInitialized)
        {
            pageViewModel.IsRootPageDisplayed = args.Source is ShellNavigationSource.PopToRoot or ShellNavigationSource.ShellItemChanged;
        }
    }
}
