using WeatherMauiApp.ViewModels;

namespace WeatherMauiApp.Pages;
public partial class HomePage : ContentPage
{
    public HomePage(HomePageViewModel vm)
    {
        InitializeComponent();

        _vm = vm;
        this.BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _vm.LoadViewModelAsync();
    }

    #region Privates
    private readonly HomePageViewModel _vm;
    #endregion
}