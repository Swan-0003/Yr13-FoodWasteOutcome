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

    if (!string.IsNullOrWhiteSpace(item))
    {
        HorizontalStackLayout itemRow = new HorizontalStackLayout
        {
            Spacing = 10
        };

        Label newItem = new Label
        {
            Text = item,
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
    }
}


}