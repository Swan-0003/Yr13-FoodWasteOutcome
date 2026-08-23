namespace FoodWasteAPP;

public partial class InventoryPage : ContentPage
{
    public InventoryPage()
    {
        InitializeComponent();
    }

private void OnAddItemClicked(object sender, EventArgs e)
{
    string item = InventoryItemEntry.Text;
    string category = InventoryCategoryEntry.Text;
    DateTime expiryDate = ExpiryDatePicker.Date ?? DateTime.Today;

    FoodItem food = new FoodItem
{
    Name = item,
    Category = category,
    ExpiryDate = expiryDate
};

FoodData.Items.Add(food);
if (FoodData.Items.Count == 1)
{
    DisplayAlert(
        "Achievement Unlocked! 🏆",
        "Getting Started - You added your first food item to your inventory.",
        "Nice!");
}

    if (!string.IsNullOrWhiteSpace(item))
    if (!string.IsNullOrWhiteSpace(category))
    {
        Grid itemRow = new Grid
        {
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = GridLength.Star },
                new ColumnDefinition { Width = GridLength.Auto }
            },

            ColumnSpacing = 10
        };

        Label newItem = new Label
        {
            Text = item + " - " + category + " - " + expiryDate.ToString("dd/MM/yyyy"),
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
            InventoryList.Children.Remove(itemRow);
            FoodData.Items.Remove(food);
        };

        Grid.SetColumn(newItem, 0);
        Grid.SetColumn(deleteButton, 1);


        itemRow.Children.Add(newItem);
        itemRow.Children.Add(deleteButton);

        InventoryList.Children.Add(itemRow);

        InventoryItemEntry.Text = "";
        InventoryCategoryEntry.Text = "";

    }
}


}