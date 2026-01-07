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
        if (BindingContext is Product p && p.Quantity > 0)
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
