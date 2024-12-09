using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

using WeatherMauiApp.Core.Services;
using WeatherMauiApp.ViewModels.Base;
using WeatherMauiApp.Database.Common;
using WeatherMauiApp.Models.ApiModels.ResponseModesl;

namespace WeatherMauiApp.ViewModels;
#nullable disable
[QueryProperty(nameof(CityName), "city")]
public partial class HomePageViewModel : ViewModelBase
{
    public HomePageViewModel(CityService cityService,
        WeatherService weatherService,
        LocationService locationService,
        WeatherDatabase weatherDatabase)
    {
        _cityService = cityService;
        _weatherService = weatherService;
        _locationService = locationService;
        _weatherDatabase = weatherDatabase;

        WeatherConditions = new List<string>
        {
            "All",
            "Sunny",
            "Clear",
            "Partly Cloudy",
            "Overcast",
            "Cloudy",
        };

        SelectedWeatherCondition = WeatherConditions.FirstOrDefault();

        Days = new List<string>
        {
            "All",
            "Today",
            "Tomorrow",
            "Day After Tomorrow",
        };

        SelectedDay = Days.FirstOrDefault();
    }

    #region Methods
    internal async ValueTask LoadViewModelAsync()
    {
        if (IsLoaded)
            return;

        IsLoaded = true;
        IsBusy = true;

        IsForecastVisible = true;
        IsForecastExpanded = true;

        if (string.IsNullOrWhiteSpace(CityName))
        {
            var coordinates = string.Empty;
            coordinates = await _locationService.GetCurrentLocationQuery();

            var weatherResponse = await _weatherService.GetWeatherUpdateByCurrentLocationAsync(coordinates, days: 7, hours: 24);
            LoadWeatherData(weatherResponse);
            var existingCity = await _weatherDatabase.GetFavoriteCityByNameAsync(City);
            if (!Equals(existingCity, null))
            {
                IsFavorite = true;
            }
        }
        else
        {
            var weatherResponse = await _weatherService.GetWeatherUpdateByCityAsync(CityName);
            LoadWeatherData(weatherResponse);
            IsFavorite = true;
        }

        IsBusy = false;
    }

    private void LoadWeatherData(ForecastJsonResponseApiModel forecastWeather)
    {
        CurrentLocation = forecastWeather.Location;
        CurrentLocation.Localtime = CurrentLocation.Localtime.Substring(11);
        CurrentWeather = forecastWeather.Current;

        City = CurrentLocation.Name;
        Country = CurrentLocation.Country;

        WeatherDescription = CurrentWeather.Condition.Text;

        WeatherIcon = CurrentWeather.Condition.Icon;

        WeatherForecastHours = SetNext24HoursData(forecastWeather);

        var forecastDays = new ObservableCollection<WeatherMauiApp.Models.ApiModels.ResponseModesl.ForecastDayResponseApiModel>(forecastWeather.Forecast.Forecastday);
        SetDaysNames(forecastDays);
        WeatherForecastDays = forecastDays;
    }

    static void SetDaysNames(ObservableCollection<WeatherMauiApp.Models.ApiModels.ResponseModesl.ForecastDayResponseApiModel> forecastDays)
    {
        foreach (var day in forecastDays)
        {
            var date = DateTime.Parse(day.Date);
            var dayName = date.DayOfWeek.ToString();

            day.Date = dayName == DateTime.Now.DayOfWeek.ToString() ? "Today" : dayName;
        }
    }

    static ObservableCollection<HourResponseApiModel> SetNext24HoursData(ForecastJsonResponseApiModel forecastWeather)
    {
        // Get next 2 days Weather
        var forecastNext48Hours = new List<HourResponseApiModel>(forecastWeather.Forecast.Forecastday[0].Hour);
        forecastNext48Hours.AddRange(forecastWeather.Forecast.Forecastday[1].Hour);

        // Get next hour index
        Func<HourResponseApiModel, bool> predicate = x => x.Time.CompareTo(DateTime.Now.ToString("yyyy-MM-dd HH:mm")) > 0;
        var nextHourIndex = forecastNext48Hours.IndexOf(forecastNext48Hours.Where(predicate).FirstOrDefault());

        // Update Time so it shows correct format
        foreach (var hour in forecastNext48Hours)
            hour.Time = hour.Time.Substring(11);

        // Set data for next 24 hours weather data
        var output = new ObservableCollection<HourResponseApiModel>(forecastNext48Hours.GetRange(nextHourIndex, 24));

        return output;
    }

    private async void FilterByWeatherCondition(string condition)
    {
        if (string.IsNullOrEmpty(City))
            return;

        IsBusy = true;
        await Task.Delay(300);

        if (condition == "Sunny" || condition == "Clear" || condition == "Partly Cloudy" || condition == "Overcast" || condition == "Cloudy")
        {
            if (SelectedDay == "Today")
            {
                var weatherResponse = await _weatherService.GetWeatherUpdateByCityAsync(City);
                CurrentLocation = weatherResponse.Location;
                CurrentLocation.Localtime = CurrentLocation.Localtime.Substring(11);
                CurrentWeather = weatherResponse.Current;

                City = CurrentLocation.Name;
                Country = CurrentLocation.Country;

                WeatherDescription = CurrentWeather.Condition.Text;

                WeatherIcon = CurrentWeather.Condition.Icon;

                var data = SetNext24HoursData(weatherResponse);
                WeatherForecastHours = new ObservableCollection<HourResponseApiModel>(data.Where(w => w.Condition.Text.ToLower() == condition.ToLower()).ToList());

                var item = weatherResponse.Forecast.Forecastday[0];
                var forecastDays = new ObservableCollection<WeatherMauiApp.Models.ApiModels.ResponseModesl.ForecastDayResponseApiModel>() { item };
                SetDaysNames(forecastDays);
                var forecastDaysList = forecastDays;
                WeatherForecastDays = new ObservableCollection<ForecastDayResponseApiModel>(forecastDays.Where(w => w.Day.Condition.Text.ToLower() == condition.ToLower()));
            }
            else if (SelectedDay == "Tomorrow")
            {
                var weatherResponse = await _weatherService.GetWeatherUpdateByCityAsync(City);

                CurrentLocation = weatherResponse.Location;
                CurrentLocation.Localtime = CurrentLocation.Localtime.Substring(11);
                CurrentWeather = weatherResponse.Current;

                City = CurrentLocation.Name;
                Country = CurrentLocation.Country;

                WeatherDescription = CurrentWeather.Condition.Text;

                WeatherIcon = CurrentWeather.Condition.Icon;

                var data = SetNext24HoursData(weatherResponse);
                WeatherForecastHours = new ObservableCollection<HourResponseApiModel>(data.Where(w => w.Condition.Text.ToLower() == condition.ToLower()).ToList());

                var item = weatherResponse.Forecast.Forecastday[1];
                var forecastDays = new ObservableCollection<WeatherMauiApp.Models.ApiModels.ResponseModesl.ForecastDayResponseApiModel>() { item };
                SetDaysNames(forecastDays);
                var forecastDaysList = forecastDays;
                WeatherForecastDays = new ObservableCollection<ForecastDayResponseApiModel>(forecastDays.Where(w => w.Day.Condition.Text.ToLower() == condition.ToLower()));

                //IsForecastVisible = false;
                //IsForecastExpanded = false;
            }
            else if (SelectedDay == "Day After Tomorrow")
            {
                var weatherResponse = await _weatherService.GetWeatherUpdateByCityAsync(City);

                CurrentLocation = weatherResponse.Location;
                CurrentLocation.Localtime = CurrentLocation.Localtime.Substring(11);
                CurrentWeather = weatherResponse.Current;

                City = CurrentLocation.Name;
                Country = CurrentLocation.Country;

                WeatherDescription = CurrentWeather.Condition.Text;

                WeatherIcon = CurrentWeather.Condition.Icon;

                var data = SetNext24HoursData(weatherResponse);
                WeatherForecastHours = new ObservableCollection<HourResponseApiModel>(data.Where(w => w.Condition.Text.ToLower() == condition.ToLower()).ToList());

                var item = weatherResponse.Forecast.Forecastday[2];
                var forecastDays = new ObservableCollection<WeatherMauiApp.Models.ApiModels.ResponseModesl.ForecastDayResponseApiModel>() { item };
                SetDaysNames(forecastDays);
                var forecastDaysList = forecastDays;
                WeatherForecastDays = new ObservableCollection<ForecastDayResponseApiModel>(forecastDays.Where(w => w.Day.Condition.Text.ToLower() == condition.ToLower()));

                //IsForecastVisible = false;
                //IsForecastExpanded = false;
            }
            else
            {
                var weatherResponse = await _weatherService.GetWeatherUpdateByCityAsync(City);
                CurrentLocation = weatherResponse.Location;
                CurrentLocation.Localtime = CurrentLocation.Localtime.Substring(11);
                CurrentWeather = weatherResponse.Current;

                City = CurrentLocation.Name;
                Country = CurrentLocation.Country;

                WeatherDescription = CurrentWeather.Condition.Text;

                WeatherIcon = CurrentWeather.Condition.Icon;

                var data = SetNext24HoursData(weatherResponse);
                WeatherForecastHours = new ObservableCollection<HourResponseApiModel>(data.Where(w => w.Condition.Text.ToLower() == condition.ToLower()).ToList());

                var forecastDays = new ObservableCollection<WeatherMauiApp.Models.ApiModels.ResponseModesl.ForecastDayResponseApiModel>(weatherResponse.Forecast.Forecastday);
                SetDaysNames(forecastDays);
                var forecastDaysList = forecastDays;
                WeatherForecastDays = new ObservableCollection<ForecastDayResponseApiModel>(forecastDays.Where(w => w.Day.Condition.Text.ToLower() == condition.ToLower()));

                IsForecastVisible = true;
                IsForecastExpanded = true;
            }
        }
        else
        {
            if (SelectedDay == "Today")
            {
                var weatherResponse = await _weatherService.GetWeatherUpdateByCityAsync(City);
                CurrentLocation = weatherResponse.Location;
                CurrentLocation.Localtime = CurrentLocation.Localtime.Substring(11);
                CurrentWeather = weatherResponse.Current;

                City = CurrentLocation.Name;
                Country = CurrentLocation.Country;

                WeatherDescription = CurrentWeather.Condition.Text;

                WeatherIcon = CurrentWeather.Condition.Icon;

                WeatherForecastHours = new ObservableCollection<HourResponseApiModel>(SetNext24HoursData(weatherResponse));

                var item = weatherResponse.Forecast.Forecastday[0];
                var forecastDays = new ObservableCollection<WeatherMauiApp.Models.ApiModels.ResponseModesl.ForecastDayResponseApiModel>() { item };
                SetDaysNames(forecastDays);
                WeatherForecastDays = new ObservableCollection<ForecastDayResponseApiModel>(forecastDays);
            }
            else if (SelectedDay == "Tomorrow")
            {
                var weatherResponse = await _weatherService.GetWeatherUpdateByCityAsync(City);

                CurrentLocation = weatherResponse.Location;
                CurrentLocation.Localtime = CurrentLocation.Localtime.Substring(11);
                CurrentWeather = weatherResponse.Current;

                City = CurrentLocation.Name;
                Country = CurrentLocation.Country;

                WeatherDescription = CurrentWeather.Condition.Text;

                WeatherIcon = CurrentWeather.Condition.Icon;

                var data = SetNext24HoursData(weatherResponse);
                WeatherForecastHours = new ObservableCollection<HourResponseApiModel>(data);

                var item = weatherResponse.Forecast.Forecastday[1];
                var forecastDays = new ObservableCollection<WeatherMauiApp.Models.ApiModels.ResponseModesl.ForecastDayResponseApiModel>() { item };
                SetDaysNames(forecastDays);
                var forecastDaysList = forecastDays;
                WeatherForecastDays = new ObservableCollection<ForecastDayResponseApiModel>(forecastDays);

                //IsForecastVisible = false;
                //IsForecastExpanded = false;
            }
            else if (SelectedDay == "Day After Tomorrow")
            {
                var weatherResponse = await _weatherService.GetWeatherUpdateByCityAsync(City);

                CurrentLocation = weatherResponse.Location;
                CurrentLocation.Localtime = CurrentLocation.Localtime.Substring(11);
                CurrentWeather = weatherResponse.Current;

                City = CurrentLocation.Name;
                Country = CurrentLocation.Country;

                WeatherDescription = CurrentWeather.Condition.Text;

                WeatherIcon = CurrentWeather.Condition.Icon;

                var data = SetNext24HoursData(weatherResponse);
                WeatherForecastHours = new ObservableCollection<HourResponseApiModel>(data);

                var item = weatherResponse.Forecast.Forecastday[2];
                var forecastDays = new ObservableCollection<WeatherMauiApp.Models.ApiModels.ResponseModesl.ForecastDayResponseApiModel>() { item };
                SetDaysNames(forecastDays);
                var forecastDaysList = forecastDays;
                WeatherForecastDays = new ObservableCollection<ForecastDayResponseApiModel>(forecastDays);

                //IsForecastVisible = false;
                //IsForecastExpanded = false;
            }
            else
            {
                var weatherResponse = await _weatherService.GetWeatherUpdateByCityAsync(City);
                CurrentLocation = weatherResponse.Location;
                CurrentLocation.Localtime = CurrentLocation.Localtime.Substring(11);
                CurrentWeather = weatherResponse.Current;

                City = CurrentLocation.Name;
                Country = CurrentLocation.Country;

                WeatherDescription = CurrentWeather.Condition.Text;

                WeatherIcon = CurrentWeather.Condition.Icon;

                var data = SetNext24HoursData(weatherResponse);
                WeatherForecastHours = new ObservableCollection<HourResponseApiModel>(data);

                var forecastDays = new ObservableCollection<WeatherMauiApp.Models.ApiModels.ResponseModesl.ForecastDayResponseApiModel>(weatherResponse.Forecast.Forecastday);
                SetDaysNames(forecastDays);
                var forecastDaysList = forecastDays;
                WeatherForecastDays = new ObservableCollection<ForecastDayResponseApiModel>(forecastDays);

                IsForecastVisible = true;
                IsForecastExpanded = true;
            }
        }

        IsBusy = false;
    }

    private async void GetForecast(string forecastOption)
    {
        if (string.IsNullOrEmpty(City))
            return;

        IsBusy = true;
        await Task.Delay(300);

        if (forecastOption == "Today")
        {
            var weatherResponse = await _weatherService.GetWeatherUpdateByCityAsync(City);
            CurrentLocation = weatherResponse.Location;
            CurrentLocation.Localtime = CurrentLocation.Localtime.Substring(11);
            CurrentWeather = weatherResponse.Current;

            City = CurrentLocation.Name;
            Country = CurrentLocation.Country;

            WeatherDescription = CurrentWeather.Condition.Text;

            WeatherIcon = CurrentWeather.Condition.Icon;

            WeatherForecastHours = SetNext24HoursData(weatherResponse);

            var item = weatherResponse.Forecast.Forecastday[0];
            var forecastDays = new ObservableCollection<WeatherMauiApp.Models.ApiModels.ResponseModesl.ForecastDayResponseApiModel>() { item };
            SetDaysNames(forecastDays);
            WeatherForecastDays = forecastDays;

            //IsForecastVisible = false;
            //IsForecastExpanded = false;
        }
        else if (forecastOption == "Tomorrow")
        {
            var weatherResponse = await _weatherService.GetWeatherUpdateByCityAsync(City);

            CurrentLocation = weatherResponse.Location;
            CurrentLocation.Localtime = CurrentLocation.Localtime.Substring(11);
            CurrentWeather = weatherResponse.Current;

            City = CurrentLocation.Name;
            Country = CurrentLocation.Country;

            WeatherDescription = CurrentWeather.Condition.Text;

            WeatherIcon = CurrentWeather.Condition.Icon;

            WeatherForecastHours = SetNext24HoursData(weatherResponse);

            var item = weatherResponse.Forecast.Forecastday[1];
            var forecastDays = new ObservableCollection<WeatherMauiApp.Models.ApiModels.ResponseModesl.ForecastDayResponseApiModel>() { item };
            SetDaysNames(forecastDays);
            WeatherForecastDays = forecastDays;

            //IsForecastVisible = false;
            //IsForecastExpanded = false;
        }
        else if (forecastOption == "Day After Tomorrow")
        {
            var weatherResponse = await _weatherService.GetWeatherUpdateByCityAsync(City);

            CurrentLocation = weatherResponse.Location;
            CurrentLocation.Localtime = CurrentLocation.Localtime.Substring(11);
            CurrentWeather = weatherResponse.Current;

            City = CurrentLocation.Name;
            Country = CurrentLocation.Country;

            WeatherDescription = CurrentWeather.Condition.Text;

            WeatherIcon = CurrentWeather.Condition.Icon;

            WeatherForecastHours = SetNext24HoursData(weatherResponse);

            var item = weatherResponse.Forecast.Forecastday[2];
            var forecastDays = new ObservableCollection<WeatherMauiApp.Models.ApiModels.ResponseModesl.ForecastDayResponseApiModel>() { item };
            SetDaysNames(forecastDays);
            WeatherForecastDays = forecastDays;

            //IsForecastVisible = false;
            //IsForecastExpanded = false;
        }
        else
        {
            var weatherResponse = await _weatherService.GetWeatherUpdateByCityAsync(City);
            LoadWeatherData(weatherResponse);

            IsForecastVisible = true;
            IsForecastExpanded = true;
        }

        IsBusy = false;
    }
    #endregion

    #region Properties
    [ObservableProperty]
    string cityName;

    [ObservableProperty]
    string city;

    [ObservableProperty]
    string country;

    [ObservableProperty]
    CurrentResponseApiModel currentWeather;

    [ObservableProperty]
    string weatherDescription;

    [ObservableProperty]
    string weatherIcon;

    [ObservableProperty]
    WeatherMauiApp.Models.ApiModels.ResponseModesl.LocationResponseApiModel currentLocation;

    [ObservableProperty]
    ObservableCollection<WeatherMauiApp.Models.ApiModels.ResponseModesl.ForecastDayResponseApiModel> weatherForecastDays;

    [ObservableProperty]
    ObservableCollection<HourResponseApiModel> weatherForecastHours;

    [ObservableProperty]
    bool isFavorite;

    [ObservableProperty]
    List<string> weatherConditions;

    private string _selectedWeatherCondition;
    public string SelectedWeatherCondition
    {
        get => _selectedWeatherCondition;
        set
        {
            if (_selectedWeatherCondition == value)
                return;

            _selectedWeatherCondition = value;
            OnPropertyChanged();

            if (!string.IsNullOrEmpty(_selectedWeatherCondition))
                FilterByWeatherCondition(_selectedWeatherCondition);
        }
    }

    [ObservableProperty]
    List<string> days;

    private string _selectedDay;
    public string SelectedDay
    {
        get => _selectedDay;
        set
        {
            if (_selectedDay == value)
                return;

            _selectedDay = value;
            OnPropertyChanged();

            if (!string.IsNullOrEmpty(_selectedDay))
                GetForecast(_selectedDay);
        }
    }

    [ObservableProperty]
    bool isForecastExpanded;

    [ObservableProperty]
    bool isForecastVisible;
    #endregion

    #region Commands
    [RelayCommand]
    async Task ToggleFavorite()
    {
        IsFavorite = !IsFavorite;
        if (IsFavorite)
        {
            var result = await _weatherDatabase.AddToFavoriteCitiesAsync(new Database.Entities.FavoriteCity
            {
                Name = City,
                CountryCode = Country
            });

            if (result)
                await Application.Current.MainPage.DisplayAlert("Success", $"{City} added to favorites", "Ok");
        }
        else
        {
            var existingCity = await _weatherDatabase.GetFavoriteCityByNameAsync(City);
            if (!Equals(existingCity, null))
            {
                var removed = await _weatherDatabase.RemoverFromFavoriteCitiesAsync(existingCity.Id);
                if (removed)
                    await Application.Current.MainPage.DisplayAlert("Success", $"{City} removed from favorites", "Ok");
            }
        }
    }

    [RelayCommand]
    async Task ClearWeatherCondition()
        => SelectedWeatherCondition = WeatherConditions.FirstOrDefault();

    [RelayCommand]
    async Task ClearWeatherForecast()
        => SelectedDay = Days.FirstOrDefault();
    #endregion

    #region Privates
    private readonly CityService _cityService;
    private readonly WeatherService _weatherService;
    private readonly WeatherDatabase _weatherDatabase;
    private readonly LocationService _locationService;
    #endregion
}