namespace FoodWasteAPP;

public partial class MenuPage : ContentPage
{
    public MenuPage()
    {
        InitializeComponent();
    }

   private async void OnAchievementsClicked(object? sender, EventArgs e)
{
    await Navigation.PushAsync(new AchievementsPage());
}

    private async void OnSettingsClicked(object? sender, EventArgs e)
    {
        await DisplayAlert(
            "Settings",
            "Settings will appear here.",
            "Close");
    }

    private async void OnAboutClicked(object? sender, EventArgs e)
    {
        await DisplayAlert(
            "About",
            "This app helps users reduce food waste by tracking food, shopping and expiry dates.",
            "Close");
    }
}