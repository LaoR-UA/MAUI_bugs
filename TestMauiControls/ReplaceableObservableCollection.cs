using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace TestMauiControls;

public class ReplaceableObservableCollection<T> : ObservableCollection<T>
{
    public void Replace(T oldItem, T newItem)
    {
        CheckReentrancy();
        int itemIndex = Items.IndexOf(oldItem);
        if (itemIndex < 0)
        {
            itemIndex = Items.Count;
            Items.Add(newItem);
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Count)));
            OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add,
                changedItems: new List<T> { newItem }, startingIndex: itemIndex));
        }
        else
        {
            Items.Remove(oldItem);
            Items.Insert(itemIndex, newItem);
            var eventArgs = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, newItem, oldItem, itemIndex);
            OnCollectionChanged(eventArgs);
        }
    }
}
