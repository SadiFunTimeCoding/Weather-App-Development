using WeatherMauiApp.ViewModels;

namespace WeatherMauiApp.Pages;
public partial class FavoriteCitiesPage : ContentPage
{
	public FavoriteCitiesPage(FavoriteCitiesPageViewModel vm)
	{
		InitializeComponent();

        _vm = vm;
		BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _vm.LoadViewModelAsync();
    }

    #region Privates
    private readonly FavoriteCitiesPageViewModel _vm;
    #endregion
}