using WeatherMauiApp.Core.Services;

namespace WeatherMauiApp;
public partial class App : Application
{
    // Constructor to initialize the app with a CityService instance
    public App(CityService cityService)
    {
        InitializeComponent(); // Initialize UI components
        _cityService = cityService; // Store the CityService instance

        Current.UserAppTheme = AppTheme.Light; // Set the app theme to Light

        MainPage = new AppShell(); // Set the main page of the app

        // Customize the appearance of Entry controls across platforms
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Entry), (handler, view) =>
        {
            if (view is Entry customEntry)
            {
#if ANDROID || ANDROID34_0
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent); // Remove background tint on Android
#elif IOS || MACCATALYST
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None; // Remove border style on iOS/macOS
#elif WINDOWS
                // Windows customization can be added here if needed
#endif
            }
        });

        // Customize the appearance of Picker controls across platforms
        Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping(nameof(Picker), (handler, view) =>
        {
#if ANDROID || ANDROID34_0
            handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent); // Remove background tint on Android
#elif IOS || MACCATALYST
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None; // Remove border style on iOS/macOS
#elif WINDOWS
                // Windows customization can be added here if needed
#endif
        });
    }

    // Override method executed when the app starts
    protected override async void OnStart()
    {
        base.OnStart(); // Call the base implementation

        await _cityService.RefreshCityAccessTokenAsync(); // Refresh the access token for city services
    }

    #region Privates
    // Private field to hold the CityService instance
    private readonly CityService _cityService;
    #endregion
}
