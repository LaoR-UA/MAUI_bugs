using TestMauiControls.ViewModels;

namespace TestMauiControls;

public partial class MenuPage
{
    public MenuPage(MenuPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}