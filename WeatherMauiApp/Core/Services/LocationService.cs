namespace WeatherMauiApp.Core.Services;
public class LocationService
{
    public LocationService(IGeolocation geolocation)
    {
        _geolocation = geolocation;
    }

    public async Task<Location> GetCurrentLocation()
    {
        var defaultLoaction = new Location();

        try
        {
            var permission = await CheckLocationPermission();
            if (!permission) return defaultLoaction;

            var location = await Geolocation.Default.GetLastKnownLocationAsync();
            if (location == null) return defaultLoaction;

            return location;
        }
        catch (Exception e)
        {
            await Application.Current.MainPage.DisplayAlert("Weather App", e.Message, "Ok");

            return defaultLoaction;
        }
    }

    public async Task<string> GetCurrentLocationQuery()
    {
        var locationData = await GetCurrentLocation();
        var currentLocation = $"{locationData.Latitude},{locationData.Longitude}";

        return currentLocation;
    }

    async Task<bool> CheckLocationPermission()
    {
        var locationWhenInUse = new Permissions.LocationWhenInUse();
        var status = await locationWhenInUse.CheckStatusAsync();

        if (status == PermissionStatus.Granted) return true;

        var userChoice = await MainThread.InvokeOnMainThreadAsync<PermissionStatus>(async () =>
        {
            var response = await locationWhenInUse.RequestAsync();
            return response;
        });

        return userChoice == PermissionStatus.Granted;
    }

    #region Privates
    private readonly IGeolocation _geolocation;
    #endregion
}