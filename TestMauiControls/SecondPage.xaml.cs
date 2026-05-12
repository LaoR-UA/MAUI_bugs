using TestMauiControls.ViewModels;

namespace TestMauiControls;

public partial class SecondPage
{
    public SecondPage(SecondPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}