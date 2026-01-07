using ShoppingList.Models;
using ShoppingList.Services;
using System.Collections.ObjectModel;

namespace ShoppingList.Views;

public partial class MainPage : ContentPage
{
    public static ObservableCollection<Category> Categories { get; private set; } = new();

    static readonly FileService fileService = new();

    public MainPage()
    {
        InitializeComponent();

        var loaded = fileService.Load();

        if (loaded.Count == 0)
        {
            loaded.Add(new Category { Name = "Nabiał" });
            loaded.Add(new Category { Name = "Warzywa" });
        }

        Categories = new ObservableCollection<Category>(loaded);
        CategoriesList.ItemsSource = Categories;
    }

    private async void AddCategoryClicked(object sender, EventArgs e)
    {
        string name = await DisplayPromptAsync(
            "Nowa kategoria",
            "Podaj nazwę kategorii:");

        if (string.IsNullOrWhiteSpace(name))
            return;

        Categories.Add(new Category { Name = name.Trim() });
        SaveCategories();
    }

    public static void SaveCategories()
    {
        fileService.Save(Categories.ToList());
    }
}
