using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TestMauiControls;

public partial class ItemViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Text))]
    private int? selectedIndex;

    public Guid Id { get; set; }
    
    public string Name { get; set; } = string.Empty;

    public string Text => $"{Name} #{Number} (rated: {Rating})";

    private string Rating => SelectedIndex.HasValue
        ? (SelectedIndex.Value < Segments.Count && SelectedIndex.Value >= 0
            ? Segments[SelectedIndex.Value].Text
            : "MISSING")
        : "no";

    public Action<ItemViewModel>? ReplaceAction { get; set; }
    
    public List<SegmentViewModel> Segments { get; set; } = [];
    
    public int Number { get; set; }

    [RelayCommand]
    private void Replace()
    {
        ReplaceAction?.Invoke(this);
    }
}