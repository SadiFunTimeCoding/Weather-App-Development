using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.Input;

using Mopups.Interfaces;

using WeatherMauiApp.Core.Services;
using WeatherMauiApp.ViewModels.Base;
using WeatherMauiApp.Models.BindingModels;
using WeatherMauiApp.Database.Common;

namespace WeatherMauiApp.ViewModels.Popups;
public partial class CitySearchPopupViewModel : ViewModelBase
{
    public CitySearchPopupViewModel(CityService cityService,
        IPopupNavigation popupNavigation,
        WeatherDatabase weatherDatabase)
    {
        _cityService = cityService;
        _weatherDatabase = weatherDatabase;
        _popupNavigation = popupNavigation;

        CityList = new ObservableCollection<CityModel>();
    }

    internal void Init(HomePageViewModel parentVm)
        => _homePageViewModel = parentVm;

    internal void Init(FavoriteCitiesPageViewModel parentVm)
        => _favoriteCitiesPageViewModel = parentVm;

    private string _searchText;
    public string SearchText
    {
        get => _searchText;
        set
        {
            _searchText = value;
            OnPropertyChanged();
        }
    }

    private CityModel _currentCity;
    public CityModel CurrentCity
    {
        get => _currentCity;
        set
        {
            _currentCity = value;
            OnPropertyChanged();

            if (!Equals(_currentCity, null))
            {
                _favoriteCitiesPageViewModel?.LoadViewModelAsync();
            }
        }
    }

    private ObservableCollection<CityModel> _cityList;
    public ObservableCollection<CityModel> CityList
    {
        get => _cityList;
        set
        {
            _cityList = value;
            OnPropertyChanged();
        }
    }

    [RelayCommand]
    private async Task Close()
       => await _popupNavigation.PopAsync();

    [RelayCommand]
    private async Task Search(object param)
    {
        IsBusy = true;
        await Task.Delay(300);

        if (!string.IsNullOrWhiteSpace(SearchText))
        {
            var cityDataResponse = await _cityService.GetCitiesAsync(SearchText);
            CityList = new ObservableCollection<CityModel>(cityDataResponse?.Data?.Select(s => new CityModel { Name = s.Name, CountryCode = s.Address.CountryCode })?.ToList() ?? new List<CityModel>());
        }
        else
        {
            CityList = new ObservableCollection<CityModel>();
        }

        IsBusy = false;
    }

    [RelayCommand]
    private async Task AddToFavorites(object item)
    {
        if (item is CityModel model)
        {
            IsBusy = true;
            await Task.Delay(300);

            var existingCity = await _weatherDatabase.GetFavoriteCityByNameAsync(model.Name);
            if (!Equals(existingCity, null))
            {
                await _weatherDatabase.RemoverFromFavoriteCitiesAsync(existingCity.Id);
            }
            else
            {
                await _weatherDatabase.AddToFavoriteCitiesAsync(new Database.Entities.FavoriteCity
                {
                    Name = model.Name,
                    CountryCode = model.CountryCode
                });
            }

            await _popupNavigation.PopAsync();

            IsBusy = false;

            if (!Equals(_favoriteCitiesPageViewModel, null))
                await _favoriteCitiesPageViewModel.LoadViewModelAsync();
        }
    }

    #region Privates
    private readonly CityService _cityService;
    private HomePageViewModel _homePageViewModel;
    private readonly WeatherDatabase _weatherDatabase;
    private readonly IPopupNavigation _popupNavigation;
    private FavoriteCitiesPageViewModel _favoriteCitiesPageViewModel;
    #endregion
}
