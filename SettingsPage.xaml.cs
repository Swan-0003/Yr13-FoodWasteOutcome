namespace FoodWasteAPP;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
    }

private async void OnChangeProfilePictureClicked(object? sender, EventArgs e)
{
    FileResult? result = await FilePicker.Default.PickAsync(new PickOptions
    {
        PickerTitle = "Choose a profile picture",
        FileTypes = FilePickerFileType.Images
    });

    if (result != null)
    {
        string newFile = Path.Combine(
            FileSystem.AppDataDirectory,
            result.FileName);

        using Stream sourceStream = await result.OpenReadAsync();
        using FileStream localFileStream = File.OpenWrite(newFile);

        await sourceStream.CopyToAsync(localFileStream);

        Preferences.Set("ProfileImagePath", newFile);

        ProfileImage.Source = ImageSource.FromFile(newFile);
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
protected override void OnAppearing()
{
    base.OnAppearing();

    NameEntry.Text = Preferences.Get("UserName", "");

    string imagePath = Preferences.Get("ProfileImagePath", "");

    if (!string.IsNullOrWhiteSpace(imagePath) && File.Exists(imagePath))
    {
        ProfileImage.Source = ImageSource.FromFile(imagePath);
    }

    string selectedIcon = Preferences.Get("ProfileIcon", "");

if (!string.IsNullOrWhiteSpace(selectedIcon))
{
    SelectedProfileLabel.Text = "Selected: " + selectedIcon;
}
}

}