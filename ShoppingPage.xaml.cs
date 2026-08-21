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
    Text = item,
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
    ShoppingList.Children.Remove(itemRow);
};

Grid.SetColumn(newItem, 0);
Grid.SetColumn(deleteButton, 1);

itemRow.Children.Add(newItem);
itemRow.Children.Add(deleteButton);

ShoppingList.Children.Add(itemRow);

        ShoppingItemEntry.Text = "";
    }
}

}