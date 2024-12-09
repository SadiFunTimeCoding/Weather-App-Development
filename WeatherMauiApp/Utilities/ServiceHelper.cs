namespace WeatherMauiApp.Utilities;
public static class ServiceHelper
{
    public static T GetService<T>() => Current.GetService<T>();

    public static IServiceProvider Current =>
#if WINDOWS10_0_17763_0_OR_GREATER
    MauiWinUIApplication.Current.Services;
#elif ANDROID || ANDROID34_0
        MauiApplication.Current.Services;
#elif IOS
    MauiUIApplicationDelegate.Current.Services;
#else
    null;
#endif
}