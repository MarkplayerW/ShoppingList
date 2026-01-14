using ShoppingList.Models;

namespace ShoppingList.Views;

public partial class ProductView : ContentView
{
    public ProductView()
    {
        InitializeComponent();
    }

    private void PlusClicked(object sender, EventArgs e)
    {
        if (BindingContext is Product p)
        {
            p.Quantity++;
            MainPage.SaveCategories();
        }
    }

    private void MinusClicked(object sender, EventArgs e)
    {
        if (BindingContext is Product p && p.Quantity > 1)
        {
            p.Quantity--;
            MainPage.SaveCategories();
        }
    }

    private void BoughtChanged(object sender, CheckedChangedEventArgs e)
    {
        if (BindingContext is Product p &&
            Parent?.BindingContext is Category c)
        {
            p.IsBought = e.Value;
            c.SortProducts();
            MainPage.SaveCategories();
        }
    }

    private void valueCheck(object sender, EventArgs e)
    {
        if (BindingContext is not Product p)
            return;

        var entry = sender as Entry;
        if (entry == null)
            return;

        if (!int.TryParse(entry.Text, out int value) || value < 1)
        {
            p.Quantity = 1;
            entry.Text = "1";
        }
        else
        {
            p.Quantity = value;
        }

        MainPage.SaveCategories();
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        if (BindingContext is Product p &&
            Parent?.BindingContext is Category c)
        {
            c.Products.Remove(p);
            MainPage.SaveCategories();
        }
    }
}
