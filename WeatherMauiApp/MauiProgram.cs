using CommunityToolkit.Maui;

using Microsoft.Extensions.Logging;

using Mopups.Hosting;

using WeatherMauiApp.Pages;
using WeatherMauiApp.ViewModels;
using WeatherMauiApp.Core.Services;
using WeatherMauiApp.Database.Common;
using Mopups.Interfaces;
using Mopups.Services;
using WeatherMauiApp.Views.Popups;
using WeatherMauiApp.ViewModels.Popups;

namespace WeatherMauiApp;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureMopups()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                fonts.AddFont("Poppins-Light.ttf", "PoppinsLight");
                fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
                fonts.AddFont("Poppins-SemiBold.ttf", "PoppinsSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<IPopupNavigation>(MopupService.Instance);
        builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);

        builder.Services.AddSingleton<HomePageViewModel>();
        builder.Services.AddSingleton<AboutPageViewModel>();
        builder.Services.AddSingleton<FavoriteCitiesPageViewModel>();

        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<FavoriteCitiesPage>();

        builder.Services.AddTransient<CitySearchPopup>();
        builder.Services.AddTransient<CitySearchPopupViewModel>();

        builder.Services.AddTransient<CityService>();
        builder.Services.AddTransient<WeatherService>();
        builder.Services.AddTransient< LocationService>();
        builder.Services.AddTransient<WeatherDatabase>();

        return builder.Build();
    }
}
