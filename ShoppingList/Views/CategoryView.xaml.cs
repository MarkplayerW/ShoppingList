using ShoppingList.Models;

namespace ShoppingList.Views;

public partial class CategoryView : ContentView
{
    public CategoryView()
    {
        InitializeComponent();
    }

    private void ToggleClicked(object sender, EventArgs e)
    {
        if (BindingContext is Category c)
            c.IsExpanded = !c.IsExpanded;
    }

    private async void AddProductClicked(object sender, EventArgs e)
    {
        if (BindingContext is not Category c)
            return;

        string name = await Shell.Current.DisplayPromptAsync(
            "Produkt",
            "Nazwa produktu:");
        if (string.IsNullOrWhiteSpace(name)) return;

        string unit = await Shell.Current.DisplayPromptAsync(
            "Jednostka",
            "Np. szt., kg, l:");
        if (string.IsNullOrWhiteSpace(unit)) return;

        string q = await Shell.Current.DisplayPromptAsync(
            "Iloœæ",
            "Podaj iloœæ:",
            accept: "OK",
            cancel: "Anuluj",
            placeholder: "1",
            keyboard: Keyboard.Numeric);

        if (!int.TryParse(q, out int qty) || qty <= 0) return;

        c.Products.Add(new Product
        {
            Name = name.Trim(),
            Unit = unit.Trim(),
            Quantity = qty
        });

        c.SortProducts();
        MainPage.SaveCategories();
    }
}
