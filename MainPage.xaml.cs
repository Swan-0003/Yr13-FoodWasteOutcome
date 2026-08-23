namespace FoodWasteAPP;

public partial class MainPage : ContentPage
{

    private void UpdateUpcomingExpiry()
{
    FoodItem? upcomingFood = null;
    int smallestDaysLeft = 4;

    foreach (FoodItem food in FoodData.Items)
    {
        int daysLeft = (food.ExpiryDate.Date - DateTime.Today).Days;

        if (daysLeft >= 0 && daysLeft <= 3 && daysLeft < smallestDaysLeft)
        {
            upcomingFood = food;
            smallestDaysLeft = daysLeft;
        }
    }

    if (upcomingFood == null)
    {
        UpcomingExpiryLabel.Text = "No food expiring soon";
    }
    else if (smallestDaysLeft == 0)
    {
        UpcomingExpiryLabel.Text = upcomingFood.Name + " expires today";
    }
    else if (smallestDaysLeft == 1)
    {
        UpcomingExpiryLabel.Text = upcomingFood.Name + " expires tomorrow";
    }
    else
    {
        UpcomingExpiryLabel.Text = upcomingFood.Name + " expires in " + smallestDaysLeft + " days";
    }
}
protected override void OnAppearing()
{
    base.OnAppearing();
    UpdateUpcomingExpiry();
}
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