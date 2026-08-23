using System.Text.Json;

namespace FoodWasteAPP;

public class FoodItem
{
    public string Name { get; set; } = "";
    public string Category { get; set; } = "";
    public DateTime ExpiryDate { get; set; }
}

public static class FoodData
{
    private const string StorageKey = "SavedFoodItems";

    public static List<FoodItem> Items { get; private set; } = LoadItems();

    public static void SaveItems()
    {
        string json = JsonSerializer.Serialize(Items);
        Preferences.Set(StorageKey, json);
    }

    private static List<FoodItem> LoadItems()
    {
        string json = Preferences.Get(StorageKey, "");

        if (string.IsNullOrWhiteSpace(json))
        {
            return new List<FoodItem>();
        }

        try
        {
            return JsonSerializer.Deserialize<List<FoodItem>>(json)
                   ?? new List<FoodItem>();
        }
        catch
        {
            return new List<FoodItem>();
        }
    }
}