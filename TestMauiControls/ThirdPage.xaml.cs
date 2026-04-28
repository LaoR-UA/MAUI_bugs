using TestMauiControls.ViewModels;

namespace TestMauiControls;

public partial class ThirdPage
{
    public ThirdPage(ThirdPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}