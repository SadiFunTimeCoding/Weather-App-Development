using System.Collections.ObjectModel;

using Mopups.Interfaces;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

using WeatherMauiApp.Pages;
using WeatherMauiApp.Utilities;
using WeatherMauiApp.Views.Popups;
using WeatherMauiApp.Core.Services;
using WeatherMauiApp.Database.Common;
using WeatherMauiApp.ViewModels.Base;
using WeatherMauiApp.Models.BindingModels;

namespace WeatherMauiApp.ViewModels;
public partial class FavoriteCitiesPageViewModel : ViewModelBase
{
    public FavoriteCitiesPageViewModel(WeatherDatabase weatherDatabase,
        WeatherService weatherService,
        IPopupNavigation popupNavigation)
    {
        _weatherService = weatherService;
        _weatherDatabase = weatherDatabase;
        _popupNavigation = popupNavigation;
    }

    #region Methods
    internal async ValueTask LoadViewModelAsync()
    {
        IsBusy = true;
        await Task.Delay(300);

        var cities = await _weatherDatabase.GetFavoriteCitiesAsync();
        List<CityModel> cityList = new List<CityModel>();
        foreach (var city in cities)
        {
            var weatherResponse = await _weatherService.GetWeatherUpdateByCityAsync(city.Name);
            if (Equals(weatherResponse, null))
                continue;

            cityList.Add(new CityModel
            {
                Id = city.Id,
                Name = city.Name,
                Country = weatherResponse.Location.Country,
                CurrentCondition = weatherResponse.Current.Condition.Text,
                CurrentTemC = weatherResponse.Current.TempC,
                Icon = weatherResponse.Current.Condition.Icon,
            });
        }

        FavoriteCities = new ObservableCollection<CityModel>(cityList);
        HasNoData = !FavoriteCities.Any();
        
        IsBusy = false;
    }
    #endregion

    #region Properties
    [ObservableProperty]
    ObservableCollection<CityModel> favoriteCities;

    [ObservableProperty]
    bool hasNoData;
    #endregion

    #region Commands
    [RelayCommand]
    async Task GoToHomePage(object item)
    {
        if (item is CityModel model)
        {
            var vm = ServiceHelper.GetService<HomePageViewModel>();
            vm.IsLoaded = false;

            await Shell.Current.GoToAsync($"//{nameof(HomePage)}?city={model.Name}", true);
        }
    }

    [RelayCommand]
    async Task RemoveCity(string name)
    {
        var lowerName = name.Trim().ToLower();
        var locations = await _weatherDatabase.GetFavoriteCitiesAsync();
        var selectedDbLocation = locations.Where(l => l.Name.ToLower() == lowerName).FirstOrDefault();

        if (selectedDbLocation is null)
            return;

        var isDeleted = await _weatherDatabase.RemoverFromFavoriteCitiesAsync(selectedDbLocation.Id);
        if (isDeleted)
        {
            var selectedLocation = FavoriteCities.Where(l => l.Name.ToLower() == lowerName.ToLower()).FirstOrDefault();
            if (selectedLocation is null)
                return;

            FavoriteCities.RemoveAt(FavoriteCities.IndexOf(selectedLocation));
        }
    }

    [RelayCommand]
    async Task SearchCity()
    {
        var popup = ServiceHelper.GetService<CitySearchPopup>();
        popup.Init(this);

        await _popupNavigation.PushAsync(popup);
    }
    #endregion

    #region Privates
    private readonly WeatherService _weatherService;
    private readonly WeatherDatabase _weatherDatabase;
    private readonly IPopupNavigation _popupNavigation;
    #endregion
}
