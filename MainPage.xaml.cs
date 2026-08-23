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

private async void OnMenuClicked(object? sender, EventArgs e)
{
    await DisplayAlert(
        "Menu",
        "Achievements\nSettings\nAbout",
        "Close");
}

private async void OnProfileClicked(object? sender, EventArgs e)
{
    await DisplayAlert(
        "Profile",
        "Profile customisation will be available here.",
        "Close");
}
}