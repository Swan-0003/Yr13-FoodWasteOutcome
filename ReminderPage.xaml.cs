namespace FoodWasteAPP;

public partial class ReminderPage : ContentPage
{
    public ReminderPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ShowReminders();
        BuildCalendar();

        ReminderList.IsVisible = true;
        ReminderCalendarView.IsVisible = false;
    }

    private void OnReminderListClicked(object? sender, EventArgs e)
    {
        ReminderList.IsVisible = true;
        ReminderCalendarView.IsVisible = false;
        CalendarBorder.IsVisible = false;

        ShowReminders();
    }

    private void OnReminderCalendarClicked(object? sender, EventArgs e)
    {
        ReminderList.IsVisible = false;
        ReminderCalendarView.IsVisible = true;
        CalendarBorder.IsVisible = true;

        BuildCalendar();
    }

    private void BuildCalendar()
    {
        CalendarGrid.Children.Clear();
        CalendarGrid.RowDefinitions.Clear();

        DateTime today = DateTime.Today;
        int year = today.Year;
        int month = today.Month;

        CalendarMonthLabel.Text = today.ToString("MMMM yyyy");

        string[] dayNames =
        {
            "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"
        };

        for (int i = 0; i < 7; i++)
        {
            Label dayHeader = new Label
            {
                Text = dayNames[i],
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            CalendarGrid.Add(dayHeader, i, 0);
        }

        DateTime firstDay = new DateTime(year, month, 1);

        int startColumn =
            ((int)firstDay.DayOfWeek + 6) % 7;

        int daysInMonth =
            DateTime.DaysInMonth(year, month);

        int row = 1;
        int column = startColumn;

        for (int day = 1; day <= daysInMonth; day++)
        {
            DateTime currentDate =
                new DateTime(year, month, day);

            VerticalStackLayout dayContent =
                new VerticalStackLayout
                {
                    Spacing = 3
                };

            Label dayNumber = new Label
            {
                Text = day.ToString(),
                FontAttributes = FontAttributes.Bold
            };

            dayContent.Children.Add(dayNumber);

            foreach (FoodItem food in FoodData.Items)
            {
                if (food.ExpiryDate.Date == currentDate.Date)
                {
                    Label foodLabel = new Label
                    {
                        Text = food.Name,
                        FontSize = 12,
                        LineBreakMode = LineBreakMode.WordWrap
                    };

                    dayContent.Children.Add(foodLabel);
                }
            }

            Border dayBox = new Border
            {
                Stroke = Color.FromArgb("#D0D0D0"),
                StrokeThickness = 1,
                Padding = 6,
                MinimumHeightRequest = 75,
                Content = dayContent
            };

            CalendarGrid.Add(dayBox, column, row);

            column++;

            if (column == 7)
            {
                column = 0;
                row++;
            }
        }
    }

    private void ShowReminders()
    {
        ReminderList.Children.Clear();

        foreach (FoodItem food in FoodData.Items)
        {
            int daysLeft =
                (food.ExpiryDate.Date - DateTime.Today).Days;

            if (daysLeft < 0)
            {
                ReminderList.Children.Add(
                    new Label
                    {
                        Text = food.Name + " has expired",
                        FontSize = 18
                    });
            }
            else if (daysLeft == 0)
            {
                ReminderList.Children.Add(
                    new Label
                    {
                        Text = food.Name + " expires today",
                        FontSize = 18
                    });
            }
            else if (daysLeft == 1)
            {
                ReminderList.Children.Add(
                    new Label
                    {
                        Text = food.Name + " expires tomorrow",
                        FontSize = 18
                    });
            }
            else if (daysLeft <= 3)
            {
                ReminderList.Children.Add(
                    new Label
                    {
                        Text =
                            food.Name +
                            " expires in " +
                            daysLeft +
                            " days",

                        FontSize = 18
                    });
            }
        }
    }
}