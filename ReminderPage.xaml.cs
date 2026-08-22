namespace FoodWasteAPP;

public partial class ReminderPage : ContentPage
{
    public ReminderPage()
    {
        InitializeComponent();
    }
private void ShowReminders()
{
    ReminderList.Children.Clear();
foreach (FoodItem food in FoodData.Items)
{
int daysLeft = (food.ExpiryDate.Date - DateTime.Today).Days;
if (daysLeft < 0)
{

 Label reminder = new Label
    {
        Text = food.Name + " has expired",
        FontSize = 18
    };

    ReminderList.Children.Add(reminder);
}

else if (daysLeft == 0)
          {
          Label reminder = new Label
          {
              Text = food.Name + " expires today",
              FontSize = 18
          };
          ReminderList.Children.Add(reminder);
          }

          else if (daysLeft == 1)
          {
            Label reminder = new Label
            {
                Text = food.Name + " expires tomorrow",
                FontSize = 18
            };

            ReminderList.Children.Add(reminder);
          }

          else if (daysLeft <= 3)
          {
            Label reminder = new Label
            {
                Text = food.Name + " expires in " + daysLeft + " days",
                FontSize = 18
            };
            ReminderList.Children.Add(reminder);
          }
  }

}
protected override void OnAppearing()
{
    base.OnAppearing();
    ShowReminders();
}
}