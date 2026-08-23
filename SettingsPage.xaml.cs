namespace FoodWasteAPP;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        NameEntry.Text = Preferences.Get("UserName", "");

        string selectedIcon = Preferences.Get("ProfileIcon", "");

        if (!string.IsNullOrWhiteSpace(selectedIcon))
        {
            SelectedProfileLabel.Text = "Selected: " + selectedIcon;
        }
        else
        {
            SelectedProfileLabel.Text = "No profile icon selected";
        }
    }

    private void OnProfileOneClicked(object? sender, EventArgs e)
    {
        Preferences.Set("ProfileIcon", "🌱");
        SelectedProfileLabel.Text = "Selected: 🌱";
    }

    private void OnProfileTwoClicked(object? sender, EventArgs e)
    {
        Preferences.Set("ProfileIcon", "🍎");
        SelectedProfileLabel.Text = "Selected: 🍎";
    }

    private void OnProfileThreeClicked(object? sender, EventArgs e)
    {
        Preferences.Set("ProfileIcon", "🌿");
        SelectedProfileLabel.Text = "Selected: 🌿";
    }

    private async void OnSaveProfileClicked(object? sender, EventArgs e)
    {
        string name = NameEntry.Text;

        if (!string.IsNullOrWhiteSpace(name))
        {
            Preferences.Set("UserName", name);

            await DisplayAlert(
                "Saved",
                "Your profile has been updated.",
                "OK");
        }
    }
}