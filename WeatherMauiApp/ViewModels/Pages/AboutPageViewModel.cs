using CommunityToolkit.Mvvm.Input;
using WeatherMauiApp.ViewModels.Base;

namespace WeatherMauiApp.ViewModels;
public partial class AboutPageViewModel : ViewModelBase
{
    [RelayCommand]
    async void OpenLink()
    {
        var url = "https://www.weatherapi.com/";
        await Browser.OpenAsync(url);
    }
}
