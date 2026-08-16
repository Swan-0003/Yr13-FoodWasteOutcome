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

    if (!string.IsNullOrWhiteSpace(item))
    if (!string.IsNullOrWhiteSpace(category))
    {
        HorizontalStackLayout itemRow = new HorizontalStackLayout
        {
            Spacing = 10
        };

        Label newItem = new Label
        {
            Text = item + "-" + category,
            FontSize = 16,
            VerticalOptions = LayoutOptions.Center
        };

        Button deleteButton = new Button
        {
            Text = "Delete"
        };

        deleteButton.Clicked += (sender, e) =>
        {
            InventoryList.Children.Remove(itemRow);
        };

        itemRow.Children.Add(newItem);
        itemRow.Children.Add(deleteButton);

        InventoryList.Children.Add(itemRow);

        InventoryItemEntry.Text = "";
        InventoryCategoryEntry.Text = "";

    }
}


}