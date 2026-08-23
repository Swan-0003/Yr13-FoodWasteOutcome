namespace FoodWasteAPP;

public partial class InventoryPage : ContentPage
{
    public InventoryPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Always open Inventory in List view
        InventoryList.IsVisible = true;
        InventoryGrid.IsVisible = false;

        RefreshListView();
        UpdateGridView();
    }

    private void OnListViewClicked(object? sender, EventArgs e)
    {
        InventoryList.IsVisible = true;
        InventoryGrid.IsVisible = false;

        RefreshListView();
    }

    private void OnGridViewClicked(object? sender, EventArgs e)
    {
        InventoryList.IsVisible = false;
        InventoryGrid.IsVisible = true;

        UpdateGridView();
    }

    private void RefreshListView()
    {
        InventoryList.Children.Clear();

        foreach (FoodItem food in FoodData.Items)
        {
            Grid itemRow = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition
                    {
                        Width = GridLength.Star
                    },

                    new ColumnDefinition
                    {
                        Width = GridLength.Auto
                    }
                },

                ColumnSpacing = 10
            };

            Label newItem = new Label
            {
                Text =
                    food.Name +
                    " - " +
                    food.Category +
                    " - " +
                    food.ExpiryDate.ToString("dd/MM/yyyy"),

                FontSize = 18,
                VerticalOptions = LayoutOptions.Center,
                LineBreakMode = LineBreakMode.WordWrap
            };

            Button deleteButton = new Button
            {
                Text = "Delete"
            };

            deleteButton.Clicked += (sender, e) =>
            {
                FoodData.Items.Remove(food);

                RefreshListView();
                UpdateGridView();
            };

            Grid.SetColumn(newItem, 0);
            Grid.SetColumn(deleteButton, 1);

            itemRow.Children.Add(newItem);
            itemRow.Children.Add(deleteButton);

            InventoryList.Children.Add(itemRow);
        }
    }

    private void UpdateGridView()
    {
        InventoryGrid.Children.Clear();
        InventoryGrid.RowDefinitions.Clear();

        int row = 0;
        int column = 0;

        foreach (FoodItem food in FoodData.Items)
        {
            Border foodCard = new Border
            {
                Stroke = Color.FromArgb("#D0D0D0"),
                StrokeThickness = 1,
                Padding = 15,
                Margin = 5,

                Content = new VerticalStackLayout
                {
                    Spacing = 5,

                    Children =
                    {
                        new Label
                        {
                            Text = food.Name,
                            FontSize = 18,
                            FontAttributes = FontAttributes.Bold
                        },

                        new Label
                        {
                            Text = food.Category,
                            FontSize = 15
                        },

                        new Label
                        {
                            Text =
                                "Expires: " +
                                food.ExpiryDate.ToString("dd/MM/yyyy"),

                            FontSize = 14
                        }
                    }
                }
            };

            InventoryGrid.Add(foodCard, column, row);

            column++;

            if (column == 2)
            {
                column = 0;
                row++;
            }
        }
    }

    private async void OnAddItemClicked(object? sender, EventArgs e)
    {
        string item = InventoryItemEntry.Text;
        string category = InventoryCategoryEntry.Text;

        DateTime expiryDate =
            ExpiryDatePicker.Date ?? DateTime.Today;

        if (!string.IsNullOrWhiteSpace(item) &&
            !string.IsNullOrWhiteSpace(category))
        {
            FoodItem food = new FoodItem
            {
                Name = item,
                Category = category,
                ExpiryDate = expiryDate
            };

            FoodData.Items.Add(food);

            if (FoodData.Items.Count == 1)
            {
                await DisplayAlert(
                    "Achievement Unlocked! 🏆",
                    "Getting Started - You added your first food item to your inventory.",
                    "Nice!");
            }

            InventoryItemEntry.Text = "";
            InventoryCategoryEntry.Text = "";

            RefreshListView();
            UpdateGridView();
        }
    }
}