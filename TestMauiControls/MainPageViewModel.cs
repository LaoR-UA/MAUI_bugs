namespace TestMauiControls;

public class MainPageViewModel
{
    private const int NumberOfItems = 10;

    public ReplaceableObservableCollection<ItemViewModel> Items { get; } = [];

    public MainPageViewModel()
    {
        for (int i = 1; i <= NumberOfItems; i++)
        {
            var itemViewModel = new ItemViewModel
            {
                Id = Guid.NewGuid(),
                Name = "Item",
                Number = i,
                ReplaceAction = ReplaceItem,
                Segments = [new SegmentViewModel(0), new SegmentViewModel(1), new SegmentViewModel(2)]
            };
            Items.Add(itemViewModel);
        }
    }

    private void ReplaceItem(ItemViewModel pickedItem)
    {
        ItemViewModel? itemToReplace = Items.FirstOrDefault(item => item.Id == pickedItem.Id);
        if (itemToReplace == null) return;

        int newCount = itemToReplace.Segments.Count - 1;
        if (newCount <= 0) newCount = 3;

        var replacer = new ItemViewModel
        {
            Name = "Replacer",
            Number = itemToReplace.Number + NumberOfItems,
            Id = Guid.NewGuid(),
            ReplaceAction = itemToReplace.ReplaceAction
        };

        List<SegmentViewModel> newSegments = [];
        for (var i = 0; i < newCount; i++)
        {
            var segment = new SegmentViewModel(i);
            newSegments.Add(segment);
        }

        replacer.Segments = newSegments;
        Items.Replace(itemToReplace, replacer);
    }
}