using Mopups.Pages;
using WeatherMauiApp.ViewModels;
using WeatherMauiApp.ViewModels.Popups;

namespace WeatherMauiApp.Views.Popups;
public partial class CitySearchPopup : PopupPage
{
    // Constructor to initialize the popup with a specific ViewModel
    public CitySearchPopup(CitySearchPopupViewModel vm)
    {
        InitializeComponent(); // Initialize UI components
        _vm = vm; // Store the ViewModel instance
        BindingContext = vm; // Set the BindingContext to the ViewModel
    }

    // Method to initialize the popup with a HomePageViewModel
    internal void Init(HomePageViewModel parentVm)
        => _vm.Init(parentVm); // Delegate initialization to the ViewModel

    // Method to initialize the popup with a FavoriteCitiesPageViewModel
    internal void Init(FavoriteCitiesPageViewModel parentVm)
        => _vm.Init(parentVm); // Delegate initialization to the ViewModel

    #region Privates
    // Private field to store the ViewModel instance
    private readonly CitySearchPopupViewModel _vm;
    #endregion
}
