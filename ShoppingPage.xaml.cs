namespace FoodWasteAPP;

public partial class ShoppingPage : ContentPage
{
    public ShoppingPage()
    {
        InitializeComponent();
    }

    private void OnAddItemClicked(object? sender, EventArgs e)
    {
        string item = ShoppingItemEntry.Text;

        if (!string.IsNullOrWhiteSpace(item))
        {
            Grid itemRow = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Star },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto }
                },

                ColumnSpacing = 10
            };

            Label newItem = new Label
            {
                Text = item,
                FontSize = 18,
                VerticalOptions = LayoutOptions.Center,
                LineBreakMode = LineBreakMode.WordWrap
            };

            Button inventoryButton = new Button
            {
                Text = "Move to Inventory"
            };

            Button deleteButton = new Button
            {
                Text = "Delete"
            };

            inventoryButton.Clicked += async (sender, e) =>
            {
                string choice = await DisplayActionSheet(
                    "When will this food expire?",
                    "Cancel",
                    null,
                    "1 day",
                    "2 days",
                    "3 days",
                    "4 days",
                    "5 days",
                    "Custom"
                );

                if (choice == "Cancel" || string.IsNullOrWhiteSpace(choice))
                    return;

                int days;

                if (choice == "Custom")
                {
                    string result = await DisplayPromptAsync(
                        "Custom expiry",
                        "Enter how many days until this food expires:",
                        keyboard: Keyboard.Numeric
                    );

                    if (!int.TryParse(result, out days) || days < 0)
                    {
                        await DisplayAlert(
                            "Invalid number",
                            "Please enter a valid number of days.",
                            "OK"
                        );

                        return;
                    }
                }
                else
                {
                    days = int.Parse(choice.Split(' ')[0]);
                }

                FoodItem food = new FoodItem
                {
                    Name = item,
                    Category = "Other",
                    ExpiryDate = DateTime.Today.AddDays(days)
                };

                FoodData.Items.Add(food);

                ShoppingList.Children.Remove(itemRow);

                await DisplayAlert(
                    "Moved to Inventory",
                    item + " was added to your Inventory.",
                    "OK"
                );

                await Shell.Current.GoToAsync("//InventoryPage");
            };

            deleteButton.Clicked += (sender, e) =>
            {
                ShoppingList.Children.Remove(itemRow);
            };

            Grid.SetColumn(newItem, 0);
            Grid.SetColumn(inventoryButton, 1);
            Grid.SetColumn(deleteButton, 2);

            itemRow.Children.Add(newItem);
            itemRow.Children.Add(inventoryButton);
            itemRow.Children.Add(deleteButton);

            ShoppingList.Children.Add(itemRow);

            ShoppingItemEntry.Text = "";
        }
    }
}