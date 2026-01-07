using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ShoppingList.Models;

public class Product : INotifyPropertyChanged
{
    string name = "";
    string unit = "";
    int quantity;
    bool isBought;

    public string Name
    {
        get => name;
        set { name = value; OnPropertyChanged(); }
    }

    public string Unit
    {
        get => unit;
        set { unit = value; OnPropertyChanged(); }
    }

    public int Quantity
    {
        get => quantity;
        set
        {
            quantity = value < 0 ? 0 : value;
            OnPropertyChanged();
        }
    }

    public bool IsBought
    {
        get => isBought;
        set { isBought = value; OnPropertyChanged(); }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
