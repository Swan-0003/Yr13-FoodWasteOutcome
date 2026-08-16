namespace FoodWasteAPP;

public partial class ShoppingPage : ContentPage
{
    public ShoppingPage()
    {
        InitializeComponent();
    }

    private void OnAddItemClicked(object sender, EventArgs e)
{
    string item = ShoppingItemEntry.Text;

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
    ShoppingList.Children.Remove(itemRow);
};

itemRow.Children.Add(newItem);
itemRow.Children.Add(deleteButton);

ShoppingList.Children.Add(itemRow);

        ShoppingItemEntry.Text = "";
    }
}

}