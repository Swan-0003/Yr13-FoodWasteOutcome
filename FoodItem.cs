namespace FoodWasteAPP;

public class FoodItem
{
public string Name { get; set; } = "";
public string Category { get; set; } = "";
public DateTime ExpiryDate { get; set; } 
}

public static class FoodData
{
    public static List<FoodItem> Items { get; } = new();
}