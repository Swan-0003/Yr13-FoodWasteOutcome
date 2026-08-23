namespace FoodWasteAPP;

public partial class AchievementsPage : ContentPage
{
    public AchievementsPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (FoodData.Items.Count > 0)
        {
            AchievementStatusLabel.Text = "Completed ✓";
        }
        else
        {
            AchievementStatusLabel.Text = "Not completed yet";
        }
    }
}