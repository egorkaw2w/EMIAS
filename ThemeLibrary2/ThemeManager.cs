using System;
using System.Windows;

public static class ThemeManager
{
    public static Theme CurrentTheme { get; private set; }

    private static ResourceDictionary LightThemeDictionary = new ResourceDictionary
    {
        Source = new Uri("pack://application:,,,/ThemeLibrary2;component/Themes/LightTheme.xaml")
    };

    private static ResourceDictionary DarkThemeDictionary = new ResourceDictionary
    {
        Source = new Uri("pack://application:,,,/ThemeLibrary2;component/Themes/DarkTheme.xaml")
    };

    public static void ChangeTheme(Theme theme)
    {
        if (CurrentTheme == theme) return;

        CurrentTheme = theme;
        ResourceDictionary newThemeDictionary = theme == Theme.Light ? LightThemeDictionary : DarkThemeDictionary;

        if (Application.Current.Resources.MergedDictionaries.Count > 0)
        {
            Application.Current.Resources.MergedDictionaries.RemoveAt(0);
        }

        Application.Current.Resources.MergedDictionaries.Add(newThemeDictionary);
    }
}

public enum Theme
{
    Light,
    Dark
}