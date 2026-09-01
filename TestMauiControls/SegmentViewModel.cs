using Syncfusion.Maui.Toolkit.SegmentedControl;

namespace TestMauiControls;

public class SegmentViewModel : SfSegmentItem
{
    public SegmentViewModel(int rate)
    {
        Text = rate.ToString();
        Background = rate switch
        {
            0 => new SolidColorBrush(Colors.Green),
            1 => new SolidColorBrush(Colors.Orange),
            _ => new SolidColorBrush(Colors.Red)
        };
    }
}