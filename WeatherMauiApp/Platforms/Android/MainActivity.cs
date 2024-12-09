using Android.App;
using Android.Content.PM;

namespace WeatherMauiApp;
[Activity(Theme = "@style/Maui.SplashTheme",
    LaunchMode = LaunchMode.SingleTop,
    MainLauncher = true,
    ConfigurationChanges = ConfigChanges.ScreenSize |
    ConfigChanges.Orientation |
    ConfigChanges.UiMode |
    ConfigChanges.ScreenLayout |
    ConfigChanges.SmallestScreenSize |
    ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity { }