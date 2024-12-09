using WeatherMauiApp.Pages;

namespace WeatherMauiApp;
public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(nameof(FavoriteCitiesPage), typeof(FavoriteCitiesPage));
    }
}