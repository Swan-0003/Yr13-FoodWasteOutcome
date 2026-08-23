namespace FoodWasteAPP;

public static class ThemeManager
{
    public static void ApplyTheme(string theme)
    {
        if (theme == "Blue")
        {
            ApplyBlueTheme();
        }
        else if (theme == "Dark")
        {
            ApplyDarkTheme();
        }
        else
        {
            ApplyGreenTheme();
        }

        Preferences.Set("AppTheme", theme);
    }

    private static void ApplyGreenTheme()
    {
        Application.Current.Resources["PageBackground"] =
            Color.FromArgb("{DynamicResource PageBackground}");

        Application.Current.Resources["CardBackground"] =
            Color.FromArgb("#FFFFFF");

        Application.Current.Resources["SoftCardBackground"] =
            Color.FromArgb("#E6F1E9");

        Application.Current.Resources["LightButtonBackground"] =
            Color.FromArgb("#E2EBE3");

        Application.Current.Resources["MainAccent"] =
            Color.FromArgb("#A9CBAE");

        Application.Current.Resources["StrongAccent"] =
            Color.FromArgb("#4F845B");

        Application.Current.Resources["PrimaryText"] =
            Color.FromArgb("#26352F");

        Application.Current.Resources["SecondaryText"] =
            Color.FromArgb("#66726C");

        Application.Current.Resources["BorderColor"] =
            Color.FromArgb("#D8DFDA");

        Application.Current.Resources["InputBackground"] =
            Color.FromArgb("#F5F7F5");

        Application.Current.Resources["NavigationBackground"] =
            Color.FromArgb("#E8F1E9");
    }

    private static void ApplyBlueTheme()
    {
        Application.Current.Resources["PageBackground"] =
            Color.FromArgb("#F4F9FD");

        Application.Current.Resources["CardBackground"] =
            Color.FromArgb("#FFFFFF");

        Application.Current.Resources["SoftCardBackground"] =
            Color.FromArgb("#D7EAF9");

        Application.Current.Resources["LightButtonBackground"] =
            Color.FromArgb("#DDECF8");

        Application.Current.Resources["MainAccent"] =
            Color.FromArgb("#8FC5E8");

        Application.Current.Resources["StrongAccent"] =
            Color.FromArgb("#337CC1");

        Application.Current.Resources["PrimaryText"] =
            Color.FromArgb("#203542");

        Application.Current.Resources["SecondaryText"] =
            Color.FromArgb("#60727D");

        Application.Current.Resources["BorderColor"] =
            Color.FromArgb("#CBDDE9");

        Application.Current.Resources["InputBackground"] =
            Color.FromArgb("#F1F7FB");

        Application.Current.Resources["NavigationBackground"] =
            Color.FromArgb("#D9EBF8");
    }

    private static void ApplyDarkTheme()
    {
        Application.Current.Resources["PageBackground"] =
            Color.FromArgb("#00192E");

        Application.Current.Resources["CardBackground"] =
            Color.FromArgb("#06263A");

        Application.Current.Resources["SoftCardBackground"] =
            Color.FromArgb("#079CB6");

        Application.Current.Resources["LightButtonBackground"] =
            Color.FromArgb("#0A5264");

        Application.Current.Resources["MainAccent"] =
            Color.FromArgb("#13BFC2");

        Application.Current.Resources["StrongAccent"] =
            Color.FromArgb("#20D5D1");

        Application.Current.Resources["PrimaryText"] =
            Color.FromArgb("#FFFFFF");

        Application.Current.Resources["SecondaryText"] =
            Color.FromArgb("#D7E6EC");

        Application.Current.Resources["BorderColor"] =
            Color.FromArgb("#1A5969");

        Application.Current.Resources["InputBackground"] =
            Color.FromArgb("#0A3145");

        Application.Current.Resources["NavigationBackground"] =
            Color.FromArgb("#049CB3");
    }
}