namespace FoodWasteAPP;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }
    private async void OnAddFoodClicked(object? sender, EventArgs e)
{
    await Shell.Current.GoToAsync("//InventoryPage");
}

private async void OnShoppingItemClicked(object? sender, EventArgs e)
{
    await Shell.Current.GoToAsync("//ShoppingPage");
}
}