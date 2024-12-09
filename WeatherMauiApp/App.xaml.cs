using WeatherMauiApp.Core.Services;

namespace WeatherMauiApp;
public partial class App : Application
{
    public App(CityService cityService)
    {
        InitializeComponent();
        _cityService = cityService;

        Current.UserAppTheme = AppTheme.Light;

        MainPage = new AppShell();

        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Entry), (handler, view) =>
        {
            if (view is Entry customEntry)
            {
#if ANDROID  || ANDROID34_0
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
#elif IOS || MACCATALYST
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
#endif
            }
        });

        Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping(nameof(Picker), (handler, view) =>
        {
#if ANDROID || ANDROID34_0
            handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
#elif IOS || MACCATALYST
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
#endif
        });
    }
    protected override async void OnStart()
    {
        base.OnStart();

        await _cityService.RefreshCityAccessTokenAsync();
    }

    #region Privates
    private readonly CityService _cityService;
    #endregion
}