using System.Text.Json;

namespace FoodWasteAPP;

public static class ShoppingData
{
    private const string StorageKey = "SavedShoppingItems";

    public static List<string> Items { get; private set; } = LoadItems();

    public static void SaveItems()
    {
        string json = JsonSerializer.Serialize(Items);
        Preferences.Set(StorageKey, json);
    }

    private static List<string> LoadItems()
    {
        string json = Preferences.Get(StorageKey, "");

        if (string.IsNullOrWhiteSpace(json))
        {
            return new List<string>();
        }

        try
        {
            return JsonSerializer.Deserialize<List<string>>(json)
                   ?? new List<string>();
        }
        catch
        {
            return new List<string>();
        }
    }
}