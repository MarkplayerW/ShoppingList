using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace ShoppingList.Models;

public class Category : INotifyPropertyChanged
{
    string name = "";
    bool isExpanded = true;

    public string Name
    {
        get => name;
        set { name = value; OnPropertyChanged(); }
    }

    public ObservableCollection<Product> Products { get; set; } = new();

    public bool IsExpanded
    {
        get => isExpanded;
        set { isExpanded = value; OnPropertyChanged(); }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    public void SortProducts()
    {
        var sorted = Products.OrderBy(p => p.IsBought).ToList();
        Products.Clear();
        foreach (var p in sorted)
            Products.Add(p);
    }
}
